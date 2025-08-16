using its.gamify.api.Features.Categories.Commands;
using its.gamify.api.Features.Categories.Queries;
using its.gamify.api.Features.Quarters.Commands;
using its.gamify.api.Features.Quarters.Queries;
using its.gamify.core.Models.ShareModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class QuarterController : ControllerBase
    {
        private readonly IMediator mediator;
        public QuarterController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterQuery Filter)
        {
            var res = await mediator.Send(new GetAllQuarterQuery()
            {
                Filter = Filter
            });
            return Ok(res);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuaterCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);
        }
        // [HttpPut]
        // public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updatedItem)
        // {
        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(Guid id)
        // {
        //     return NoContent();
        // }
    }
}
