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
    //display page detail of a product
    public IActionResult detail(int id)
    {
        ProductDto sampleProduct = new ProductDto
        {
            Id = 1,
            Name = "Keyboard",
            Price = 20.5,
            description = "Mechanical keyboard",
            image_url = "https://images.pexels.com/photos/585752/pexels-photo-585752.jpeg",
            category_id = 1
        };
        ViewBag.detail = sampleProduct; //inject this info to view
        return View();
    }
}