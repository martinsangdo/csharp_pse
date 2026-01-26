
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
    //cut a string to x parts
    [HttpGet]
    [Route("string/common")]
    public IActionResult findCommonCharactersInStrings(string str1, string str2)
    {
        List<char> common = new List<char>();

        foreach (char c in str1)
        {
            if (str2.Contains(c) && !common.Contains(c))
            {
                common.Add(c);
            }
        }
        
        return Ok(common);
    }
}