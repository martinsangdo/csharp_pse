
using System.Text.Json;
using WebApplication1.Services;

public class CategoryService
{
    private readonly ExternalService _externalService;
    private readonly ApplicationDbContext _db;

    public CategoryService(ExternalService externalService, ApplicationDbContext db)
    {
        _externalService = externalService;
        _db = db;
    }
    //get top categories
    public List<CategoryWithCountVM> getLeafCategories()
    {
        // var categories = _db.Category
        //                       //   .Where(c => c.ParentCategoryID != null)
        //                       //   .Take(6)
        //                       .ToList();

        /*
        SELECT c.Id, c.Name, COUNT(p.Id) AS TotalProducts
        FROM Categories c
        LEFT JOIN Products p ON p.CategoryId = c.Id
        GROUP BY c.Id, c.Name
        ORDER BY c.Name;
        */
        var categories = (from c in _db.Category
                 join p in _db.Product on c.CategoryID equals p.CategoryId into g
                 select new CategoryWithCountVM
                 {
                     CategoryID = c.CategoryID,
                     Name = c.Name,
                     TotalProducts = g.Count()
                 }).ToList();

        // int totalProductsInCategoryA = _db.Product
        //     .Count(p => p.CategoryId == categoryId);


        return categories;
    }
}