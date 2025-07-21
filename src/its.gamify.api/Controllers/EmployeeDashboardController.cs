using its.gamify.api.Features.Categories.Commands;
using its.gamify.api.Features.Categories.Queries;
using its.gamify.core.Models.ShareModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class EmployeeDashboardController : ControllerBase
    {
        private readonly IMediator mediator;
        public EmployeeDashboardController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        /// <summary>
        /// Get all Category
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterQuery Filter)
        {
            var res = await mediator.Send(new GetAllCategoriesQuery()
            {
                Filter = Filter
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
