using its.gamify.api.Features.Categories.Commands;
using its.gamify.api.Features.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
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
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);
        }

        /// <summary>
        /// Update category
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updatedItem)
        {
            var result = await mediator.Send(updatedItem);
            if (result) return NoContent();
            else return BadRequest();
        }

        /// <summary>
        /// Delete category
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await mediator.Send(new DeleteCategoryCommand()
            {
                Id = id
            });
            return res ? NoContent() : StatusCode(500);
        }
    }
}
