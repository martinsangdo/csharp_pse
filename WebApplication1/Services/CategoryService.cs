
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
    public List<Category> getLeafCategories()
    {
        var childCategories = _db.Category
                            //   .Where(c => c.ParentCategoryID != null)
                            //   .Take(6)
                              .ToList();
        return childCategories;
    }
}