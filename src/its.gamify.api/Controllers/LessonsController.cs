using its.gamify.api.Features.Lessons.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LessonsController(IMediator mediator)
        {
            _mediator = mediator;
        }
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

        // [HttpDelete]
        // public async Task<IActionResult> DelRange([FromQuery] List<Guid> ids)
        // {
        //     foreach (var id in ids)
        //     {
        //         await _mediator.Send(new DeleteLessonCommand()
        //         {
        //             Id = id
        //         });
        //     }
        //     return NoContent();
        // }
    }
}
