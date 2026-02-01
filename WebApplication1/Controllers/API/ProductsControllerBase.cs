using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

[Route("api/product")]  //
public class ProductsControllerBase : ControllerBase
{
    private readonly ProductService _productService;
    private readonly CommentService _commentService;

    public ProductsControllerBase(ProductService productService, CommentService commentService)
    {
        _productService = productService;
        _commentService = commentService;
    }
    //===== Data
    Dictionary<string, object> getSampleData()
    {
        return new Dictionary<string, object>
        {
            { "name", "Keyboard" },
            { "price", 20.5 },
            { "description", "Mechanical keyboard" }
        };
    }

    //===== GET
    [HttpGet]
    [Route("test")] //
    public IActionResult test(string name)
    {
        string receivedName = "Received: " + name;
        return Ok(receivedName);    //
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult productDetail(int id)
    {
        string response = "Received product ID: " + id;
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}/category/{catID}")]
    public IActionResult productDetailWCat(int id, int catID)
    {
        string response = "Received product ID: " + id + " catId: " + catID;
        return Ok(response);
    }

    [HttpGet]
    [Route("discount/{product_id}")]
    public IActionResult getDiscount(int product_id, int cat_id)
    {
        string response = "Received product ID: " + product_id + " catId: " + cat_id;
        return Ok(response);
    }

    [HttpGet]
    [Route("external/list")]
    public IActionResult getProductsFromExternalSource()
    {
        var products = _productService.getDummyProducts();
        return Ok(products);
    }

    //========== POST
    //get data from Form
    [HttpPost]
    [Route("")]
    public IActionResult createNewProduct(string name, string description)
    {
        string response = "Received name: " + name + ", description: " + description;
        return Ok(response);
    }

    [HttpPost("raw")]
    public async Task<IActionResult> getProductRawText()
    {
        using var reader = new StreamReader(Request.Body);
        var json = await reader.ReadToEndAsync();
        return Ok(json);
    }

    [HttpPost("discount")]
    public async Task<IActionResult> calculateDiscount()
    {
        using var reader = new StreamReader(Request.Body);
        var json = await reader.ReadToEndAsync();
        var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);
        double finalPrice = data["price"].GetDouble() - data["price"].GetDouble() * data["percent"].GetDouble();
        return Ok(finalPrice);
    }
    //received via Dto
    [HttpPost]
    public IActionResult CreateProduct([FromBody] ProductDto product)
    {
        return Ok(new
        {
            Message = "Product received",
            Data = product
        });
    }
    //========== PUT
    [HttpPut("detail")]
    public IActionResult updateDetail(string price)
    {
        Dictionary<string, object> detail = getSampleData();
        detail["price"] = price;
        return Ok(detail);
    }
    //========== 
    //create new product comment
    [HttpPost]
    [Route("comment/create")]
    public IActionResult CreateComment([FromBody] CreateCommentDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Content))
            return BadRequest(new{success= true, message = "Invalid data"});

        int rowAffected = _commentService.CreateComment(dto);
        if (rowAffected > 0)
        {
            return Ok(new{success= true});
        }
        return BadRequest(new{success= false});
    }

}
