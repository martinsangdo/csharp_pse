using Microsoft.AspNetCore.Mvc;


public class ProductsController : Controller
{
    public IActionResult list()
    {
        return View();
    }
}