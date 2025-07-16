using its.gamify.api.Features.Lessons.Commands;
using its.gamify.core.Features.Lessons.Queries;
using its.gamify.core.Models.Lessons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelById([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteLessonCommand()
            {
                Id = id
            });
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Createlesson([FromBody] CreateLessonCommand command,
              [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            return Ok(await _mediator.Send(new GetLessonByIdQuery() { Id = id }));
        }
    }
}
