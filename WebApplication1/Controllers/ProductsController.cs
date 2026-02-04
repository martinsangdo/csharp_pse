using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


public class ProductsController : Controller
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;
    private readonly CommentService _commentService;

    public ProductsController(ProductService productService, CategoryService categoryService,
        CommentService commentService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _commentService = commentService;
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

    //Product list
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

        //get products that have largest stock
        var productsHasBigStock = _productService.GetProductsHasBigStock();
        ViewBag.latestProducts = productsHasBigStock;
        //get categories
        ViewBag.categories = _categoryService.getLeafCategories();

        return View("~/Views/ogani/shop-grid.cshtml");
    }

    [Route("products/shop/detail")]
    public IActionResult showShopDetailPage()
    {
        ViewBag.product = _productService.getDummyProductDetail();
        return View("~/Views/ogani/shop-details.cshtml");
    }

    //Product list of 1 category
    [Route("/category/{categoryID}")]
    public IActionResult getProductsByCategory(int categoryID = 1)   //default category id
    {
        var products = _productService.GetAllProductsByCategory(categoryID);
        ViewBag.products = products;
        //get categories
        ViewBag.categories = _categoryService.getLeafCategories();

        return View("~/Views/ogani/category.cshtml");
    }

    //get detail from db
    [Route("products/detail/{id}")]
    public IActionResult getProductDetailById(int id)
    {
        Product? product = _productService.GetProductDetailById(id);
        if (product is null)
        {
            //todo show the error page
            return View("~/Views/Home/error.cshtml");
        }
        ViewBag.product = product;
        //search product in same categories
        List<Product> relatedProducts = _productService.getProductsInSameCategory(id, product.CategoryId);
        ViewBag.relatedProducts = relatedProducts;
        //search comments
        List<Comment> dbComments = _commentService.getCommentsOfProduct(id);
        ViewBag.comments = dbComments;
        ViewBag.comment_count = dbComments.Count();

        //
        // Console.WriteLine(Utils.ToSlug("this Shop is TOO HIGh"));
        //
        return View("~/Views/ogani/product_detail.cshtml");
    }

    //get detail from db
    [Route("product/{slug}")]
    public IActionResult getProductDetailBySlug(string slug)
    {
        Product? product = _productService.GetProductDetailBySlug(slug);
        if (product is null)
        {
            //todo show the error page
            return View("~/Views/Home/error.cshtml");
        }
        ViewBag.product = product;
        //search product in same categories
        List<Product> relatedProducts = _productService.getProductsInSameCategory(product.ProductId, product.CategoryId);
        ViewBag.relatedProducts = relatedProducts;
        //search comments
        List<Comment> dbComments = _commentService.getCommentsOfProduct(product.ProductId);
        ViewBag.comments = dbComments;
        ViewBag.comment_count = dbComments.Count();

        //
        return View("~/Views/ogani/product_detail.cshtml");
    }

    [Route("products/search")]
    public IActionResult searchProductsByKeyword(string keyword)
    {
        //get products
        var products = _productService.SearchProductsByKeyword(keyword);
        ViewBag.products = products;
        ViewBag.keyword = keyword;

        //get products that have largest stock
        var productsHasBigStock = _productService.GetProductsHasBigStock();
        ViewBag.latestProducts = productsHasBigStock;
        //get categories
        ViewBag.categories = _categoryService.getLeafCategories();

        return View("~/Views/ogani/search_results.cshtml");
    }

    [Route("products/search-by-price")]
    public IActionResult searchProductsByPrice(int min, int max)
    {
        //get products
        var products = _productService.SearchProductsByPrice(min, max);
        ViewBag.products = products;
        ViewBag.min = min;
        ViewBag.max = max;

        //get products that have largest stock
        var productsHasBigStock = _productService.GetProductsHasBigStock();
        ViewBag.latestProducts = productsHasBigStock;
        //get categories
        ViewBag.categories = _categoryService.getLeafCategories();
        
        return View("~/Views/ogani/search_results.cshtml");
    }
}