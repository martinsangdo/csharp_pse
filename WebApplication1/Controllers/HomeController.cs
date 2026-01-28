using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("hello/name")]
    public IActionResult hello(string myName)
    {
        ViewBag.name = myName;
        ViewBag.age = 18;
        return View();
    }

    public IActionResult sum(int a, int b)
    {
        ViewBag.sum = a + b;
        return View();
    }

    public IActionResult Privacy()
    {
        // List<int> numbers = new List<int>() { 2, 4, 6, 8, 10 };
        List<String> numbers = new List<String>() { "Mercedes", "Honda", "BMW" };
        ViewBag.Numbers = numbers;

        ViewBag.categories = new List<string> { "Keyboard", "Mouse", "PC", "Printer"};

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
