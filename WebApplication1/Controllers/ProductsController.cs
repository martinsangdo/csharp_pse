using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


public class ProductsController : Controller
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    public List<ProductDto> getSampleList()
    {
        // Sample product list
        var products = new List<ProductDto>
        {
            new ProductDto
            {
                Id = 1,
                Name = "Keyboard",
                Price = 20.5,
                description = "Mechanical keyboard",
                image_url = "https://images.pexels.com/photos/585752/pexels-photo-585752.jpeg",
                category_id = 1
            },
            new ProductDto
            {
                Id = 2,
                Name = "Mouse",
                Price = 10.0,
                description = "Wireless mouse",
                image_url = "https://images.pexels.com/photos/119550/pexels-photo-119550.jpeg",
                category_id = 2
            }
        };
        return products;
    }

    public IActionResult list()
    {
        ViewBag.products = getSampleList();
        //sample categories
        ViewBag.categories = new List<string> { "Keyboard", "Mouse", "PC", "Printer" };
        //
        return View();
    }

    public IActionResult external_list()
    {
        ViewBag.products = _productService.getDummyProducts();
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

    [Route("products/shop")]    //custom url, show list of products in homepage
    public IActionResult showShopPage()
    {
        List<Product> dbProducts = _productService.getAllProducts();
        ViewBag.products = dbProducts;  //_productService.getDummyProducts();
        return View("~/Views/ogani/shop-grid.cshtml");
    }

    [Route("/products/{page}")]
    public IActionResult showShopPagination(int page = 1)   //default page is 1
    {
        const int pageSize = 3; //assumming 1 page displays 3 products
        //get products
        var products = _productService.GetListPagination(page, pageSize);
        ViewBag.products = products.Data;
        ViewBag.Page = products.Page;
        ViewBag.Total = products.Total;
        ViewBag.TotalPage = products.Total / pageSize;
        ViewBag.Limit = products.Limit;

        return View("~/Views/ogani/shop-grid.cshtml");
    }
    
    [Route("products/shop/detail")]    //custom url
    public IActionResult showShopDetailPage()
    {
        ViewBag.product = _productService.getDummyProductDetail();
        return View("~/Views/ogani/shop-details.cshtml");
    }
}