using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers;

public class IndexController : BaseController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Welcome to the Gamify API!");
    }
}