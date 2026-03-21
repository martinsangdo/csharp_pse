using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

[ApiController]
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
    //create with basic validation
    [HttpPost("create_with_basic_validation")]
    public IActionResult CreateProductWithBasicValidation(CreateProductDto dto)
    {
        _productService.CreateProduct(dto);
        return Ok("Product Created Successfully");
    }

    [HttpPost("bulk_create")]
    public async Task<IActionResult> BulkCreate([FromBody] List<CreateProductDto> products)
    {
        int numberOfProducts = await _productService.CreateBulkProducts(products);
        return Ok("Inserted successfully with total: " + numberOfProducts);
    }

    [HttpPost("bulk_upsert")]
    public async Task<IActionResult> BulkUpsert([FromBody] List<CreateProductDto> products)
    {
        int numberOfProducts = await _productService.BulkUpsertProducts(products);
        return Ok("Upserted successfully with total: " + numberOfProducts);
    }
    //========== PUT
    [HttpPut("detail")]
    public IActionResult updateDetail(string price)
    {
        Dictionary<string, object> detail = getSampleData();
        detail["price"] = price;
        return Ok(detail);
    }

    [HttpPut("deduct_stock")]
    public IActionResult deductStock(int deductNum)
    {
        string result = _productService.deductStock(deductNum);
        return Ok(result);
    }
    //========== 
    //create new product comment
    [HttpPost]
    [Route("comment/create")]
    public IActionResult CreateComment([FromBody] CreateCommentDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Content))
            return BadRequest(new { success = true, message = "Invalid data" });

        int rowAffected = _commentService.CreateComment(dto);
        if (rowAffected > 0)
        {
            return Ok(new { success = true });
        }
        return BadRequest(new { success = false });
    }

    //convert slug for all products
    [HttpPut("convert-slugs")]
    public IActionResult convertSlugForAllProducts()
    {
        _productService.convertSlugForAllProducts();
        return Ok();
    }

    [Route("search")]
    public IActionResult searchProductsByKeyword(string keyword)
    {
        //get products
        var products = _productService.SearchProductsByKeyword(keyword);

        return Ok(products);
    }
    //======
    private readonly string[] allowedImgExtensions = { ".jpg", ".jpeg", ".png" };
    private readonly string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

    string validateImageFile(IFormFile? file)
    {
        if (file == null || file.Length == 0)
            return "No file uploaded.";
        // Validate extension
        var ext = Path.GetExtension(file.FileName).ToLower();
        if (!allowedImgExtensions.Contains(ext))
            return "Only image files are allowed.";
        // Validate content type (extra protection)
        if (!file.ContentType.StartsWith("image/"))
            return "Invalid file type.";
        if (file.Length > 5 * 1024 * 1024)  //maximum 5MB
            return "File too large.";
        //add more validation, if any
        return "";  //file is a valid image file
    }
    
    [HttpPost]
    [Route("upload_image")]
    public async Task<IActionResult> UploadImage()
    {
        var file = Request.Form.Files.FirstOrDefault();
        string errorValidation = validateImageFile(file);
        if (errorValidation != "")
            return BadRequest(errorValidation);
        var filePath = Path.Combine(folderPath, file.FileName);
        // Save file to server, at defined folder
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        var fileUrl = $"{Request.Scheme}://{Request.Host}/uploads/{file.FileName}";
        return Ok(new
        {
            message = "Upload successful",
            url = fileUrl    //public url
        });
    }

}
