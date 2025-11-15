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
}
