using its.gamify.core.Features.AvailablesData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private Ultils Ultils { get; set; }
        private readonly IMediator mediator;
        public CategoriesController(Ultils ultils,
            IMediator mediator)
        {
            this.mediator = mediator;
            Ultils = ultils;
        }
        /// <summary>
        /// Get all Category
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 0,
                                        [FromQuery] int pageSize = 10,
                                        [FromQuery] string searchTerm = ""
                                        )
        {
            return Ok(Ultils.categories);

        }
    }
}
