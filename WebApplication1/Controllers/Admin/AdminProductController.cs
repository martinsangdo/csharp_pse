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
        //bar chart
        List<CategoryWithCountVM> categories = _categoryService.getLeafCategories();
        List<string> labels = new List<string>();
        List<int> data = new List<int>();

        foreach (CategoryWithCountVM cat in categories)
        {
            labels.Add(cat.Name);
            data.Add(cat.TotalProducts);
        }
        ViewBag.singleChartLabels = labels;
        ViewBag.singleChartData = data;
        //line chart
        

        return View("~/Views/dashmin/chart.cshtml");
    }

}