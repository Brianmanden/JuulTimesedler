using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JuulTimesedler_BE.Controllers;

[EnableCors("AllowAll")]
public class DemoController : Controller
{
    [HttpGet("api/demo")]
    public IActionResult Get()
    {
        return Ok(new
        {
            Message = "Hello from Umbraco Backend!",
            ServerTime = DateTime.Now.ToString("F")
        });
    }
}
