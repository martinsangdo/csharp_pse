using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

[Route("api/product")]  //
public class ProductsControllerBase : ControllerBase
{
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
        var data = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
        Console.WriteLine(data["price"]);
        return Ok(data["price"]);
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

    //========== DELETE

}
