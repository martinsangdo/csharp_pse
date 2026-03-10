
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
        SELECT c.category_id, c.Name, SUM(p.Stock) AS TotalProducts
        FROM category c
        LEFT JOIN product p ON p.category_id = c.category_id
        GROUP BY c.category_id, c.Name
        ORDER BY TotalProducts;
        */
        var categories = (from c in _db.Category
                          join p in _db.Product on c.CategoryID equals p.CategoryId into g
                          orderby g.Sum(p => p.Stock) ascending    //descending
                          select new CategoryWithCountVM
                          {
                              CategoryID = c.CategoryID,
                              Name = c.Name,
                              TotalProducts = g.Sum(p => p.Stock)
                          }).ToList();

        // int totalProductsInCategoryA = _db.Product
        //     .Count(p => p.CategoryId == categoryId);


        return categories;
    }
}