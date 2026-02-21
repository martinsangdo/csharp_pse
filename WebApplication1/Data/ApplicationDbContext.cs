using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Product { get; set; } //DbSet<Product>: refer to the class "Product", Product -> refer to table named "product"
    public DbSet<Category> Category { get; set; }
    public DbSet<Comment> Comment { get; set; }

    public DbSet<Account> user_account { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //because EF extension maps to the table "Products" by default
        //run: dotnet clean & dotnet build
        modelBuilder.Entity<Product>().ToTable("product");
    }

}
