
using System.Collections;
using Microsoft.AspNetCore.Mvc;

// [ApiController]
// [Route("api/demo")]
public class DemoControllerBase : ControllerBase    //must have public
{
    //cut a string to x parts
    [HttpGet]
    [Route("string/parts")]
    public IActionResult cutString(string str, int x)
    {
        List<string> parts = new List<string>();
        for (int i = 0; i < str.Length; i += x)
        {
            int length = Math.Min(x, str.Length - i);
            parts.Add(str.Substring(i, length));
        }
        return Ok(parts);
    }
}