using Microsoft.AspNetCore.Mvc;


public class ProductsController : Controller
{
    public IActionResult list()
    {
        return View();
    }


    [Route("shop/products")]    //custom url
    public IActionResult pageList()
    {
        return View("Product_List");    //html page
    }
}