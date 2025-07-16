using its.gamify.api.Features.LearningProgresses.Commands;
using its.gamify.core.Features.LearningProgresses.Queries;
using its.gamify.core.Models.Lessons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [ApiController]
    [Route("api/learning-progresses")]
    public class LearningProgressesController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> MoveToNextLesson([FromBody] LearningProgessUpsertModel model)
        {
            return Ok(await _mediator.Send(new UpsertProgressCommand()
            {
                Model = model
            }));
        }

    }
}
