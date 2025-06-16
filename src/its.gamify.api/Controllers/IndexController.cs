using its.gamify.core;
using Microsoft.AspNetCore.Mvc;
namespace its.gamify.api.Controllers;

public class IndexController : BaseController
{
    [HttpGet]

    public IActionResult Get([FromServices] IUnitOfWork unitOfWork)
    {
        unitOfWork.SeedData();
        return Ok("Welcome to the Gamify API!");
    }
}