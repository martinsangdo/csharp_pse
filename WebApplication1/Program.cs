using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ExternalService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<AccountService>();
//JWT
builder.Services.AddSingleton<JwtService>();
var jwt     = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer           = false,   //turn this to true if you have issuer
            ValidateAudience         = false,
            ValidateLifetime         = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey         = new SymmetricSecurityKey(
                                           Encoding.UTF8.GetBytes(jwt["SecretKey"]!))
        };
        //add event to see the detail error
        options.Events = new JwtBearerEvents
        {
            //read token from cookie instead of header Authorization
            OnMessageReceived = context =>
            {
                var token = context.Request.Cookies["token"];
                if (!string.IsNullOrEmpty(token))
                    context.Token = token;
                return Task.CompletedTask;
            },
            // Fires when token validation fails
            OnAuthenticationFailed = context =>
            {
                string message = context.Exception switch
                {
                    SecurityTokenExpiredException    => "Token has expired.",
                    SecurityTokenInvalidSignatureException => "Token signature is invalid.",
                    SecurityTokenInvalidIssuerException    => "Token issuer is invalid.",
                    SecurityTokenInvalidAudienceException  => "Token audience is invalid.",
                    SecurityTokenNotYetValidException      => "Token is not valid yet.",
                    _                                      => "Token is invalid."
                };

                context.Response.StatusCode  = 401;
                context.Response.ContentType = "application/json";
                context.Response.WriteAsync($"{{\"error\": \"{message}\"}}");
                return Task.CompletedTask;
            },

            // Fires when no token is provided
            OnChallenge = context =>
            {
                if (!context.Response.HasStarted)
                {
                    context.HandleResponse(); // suppress default 401
                    context.Response.StatusCode  = 401;
                    context.Response.ContentType = "application/json";
                    context.Response.WriteAsync("{\"error\": \"No token provided. Please include Authorization: Bearer <token>\"}");
                }
                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddAuthorization();

//connect to SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseStaticFiles();   //v8

// app.MapStaticAssets();   //v9

app.UseAuthentication(); // ← must come before UseAuthorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    // .WithStaticAssets(); //v9


app.Run();
