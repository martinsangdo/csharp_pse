using Microsoft.AspNetCore.Mvc;

[Route("admin")]
public class AdminProductController : Controller
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;
    private readonly CommentService _commentService;

    public AdminProductController(ProductService productService, CategoryService categoryService,
        CommentService commentService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _commentService = commentService;
    }

    [Route("dashboard")]
    public IActionResult showAdminDashboard()
    {
        // ViewBag.singleChartLabels = new List<string> { "category 1", "category 2", "category 3" };
        // ViewBag.singleChartData = new List<int> { 3, 6, 5};
        List<CategoryWithCountVM> categories = _categoryService.getLeafCategories();
        List<string> labels = new List<string>();
        List<int> data = new List<int>();

        foreach (CategoryWithCountVM cat in categories)
        {
            labels.Add(cat.Name);
            data.Add(cat.TotalProducts);
        }
        // data.Sort(); 
        // var combined = labels
        // .Select((name, index) => new 
        // {
        //     Name = name,
        //     Number = data[index]
        // })
        // .OrderBy(x => x.Number)
        // .ToList();
        // labels = combined.Select(x => x.Name).ToList();
        // data = combined.Select(x => x.Number).ToList();

        ViewBag.singleChartLabels = labels;
        ViewBag.singleChartData = data;

        return View("~/Views/dashmin/chart.cshtml");
    }

}