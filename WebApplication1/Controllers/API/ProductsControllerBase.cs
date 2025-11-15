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
}
