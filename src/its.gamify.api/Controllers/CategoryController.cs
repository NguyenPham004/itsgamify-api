using its.gamify.api.Features.Categories.Commands;
using its.gamify.api.Features.Categories.Queries;
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
            var res = await mediator.Send(new GetAllCategoriesQuery()
            {
                PageIndex = pageNumber,
                SearchTerm = searchTerm,
                PageSize = pageSize
            });
            return Ok(res);

        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);
        }
    }
}
