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
        ViewBag.singleChartLabels = new List<string> { "category 1", "category 2", "category 3" };
        ViewBag.singleChartData = new List<int> { 3, 6, 5};

        return View("~/Views/dashmin/chart.cshtml");
    }

}