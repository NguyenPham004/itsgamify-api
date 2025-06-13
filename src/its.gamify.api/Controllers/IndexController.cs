<<<<<<< HEAD
using its.gamify.core;
=======
>>>>>>> 13b13c3 (modify)
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers;

public class IndexController : BaseController
{
    [HttpGet]
<<<<<<< HEAD
    public IActionResult Get([FromServices] IUnitOfWork unitOfWork)
    {
        unitOfWork.SeedData();
=======
    public IActionResult Get()
    {
>>>>>>> 13b13c3 (modify)
        return Ok("Welcome to the Gamify API!");
    }
}