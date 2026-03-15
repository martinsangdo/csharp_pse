using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/account")]  //
public class AccountControllerBase : ControllerBase
{
    private readonly AccountService _accountService;
    private readonly JwtService _jwtService;

    public AccountControllerBase(AccountService accountService, JwtService jwtService)
    {
        _accountService = accountService;
        _jwtService = jwtService;
    }

    //create with basic validation
    [HttpPost("create_with_basic_validation")]
    public IActionResult CreateAccountWithBasicValidation(CreateAccountDto dto)
    {
        _accountService.CreateAccount(dto);
        return Ok("Account Created Successfully");
    }

    //simulate login function
    [HttpPost("login")]
    public IActionResult Login([FromForm] string email, [FromForm] string hashedPassword)
    {
        //give sample email and password
        if (email != "user@example.com" || hashedPassword != "password123")
            return Unauthorized(new { message = "Invalid credentials" });
        var token = _jwtService.GenerateToken(
            userId: "user-001", //test ID
            email:  email,
            phone: "0905432123"
        );
        return Ok(new { token });
    }

    [Authorize]
    [HttpGet("profile")]
    public IActionResult Profile()
    {
        //User is a built-in property inherited from ControllerBase after going through JWT middleware
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var email  = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
        var phone = User.FindFirst("phone")?.Value;
        return Ok(new { userId, email, phone});
    }

    //register new account, return JWT token if success
    [HttpPost("register")]
    public IActionResult CreateNewAccount(CreateAccountDto dto) //use [FromForm] if submit by Form in HTML
    {
        int resultCode = _accountService.CreateNonDuplicatedAccount(dto);
        if (resultCode == 0)
        {
            //email duplicated
            return Conflict(new { message = "Email already exists." });
        }
        //create token
        var token = _jwtService.GenerateToken(
            userId: resultCode.ToString(), //test ID
            email:  dto.email,
            phone: dto.phone
        );
        return Ok(new { token });
    }

    //simulate login function and store data in cookie
    [HttpPost("login_with_cookie")]
    public IActionResult LoginWithCookie([FromForm] string email, [FromForm] string hashedPassword)
    {
        //give sample email and password
        if (email != "user@example.com" || hashedPassword != "password123")
            return Unauthorized(new { message = "Invalid credentials" });
        var token = _jwtService.GenerateToken(
            userId: "user-001", //test ID
            email:  email,
            phone: "0905432123"
        );
        // Store token in HttpOnly cookie
        Response.Cookies.Append("token", token, new CookieOptions
        {
            HttpOnly = true,    // JS cannot read this cookie
            Secure   = false,   // HTTPS only (set false for localhost dev)
            SameSite = SameSiteMode.Strict, //only same domain can access
            Expires  = DateTimeOffset.UtcNow.AddMinutes(60) //invalid after 60 mins
        });
        // do NOT return the token in the body — it's already in the cookie
        return Ok(new { success = true, message = "Logged in successfully." });
    }

    [Authorize]
    [HttpGet("profile_with_cookie")]
    public IActionResult ProfileWithCookie()
    {
        //
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
        return Ok(new { userId, email});
    }
}