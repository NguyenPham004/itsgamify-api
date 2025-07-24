using its.gamify.api.Features.Categories.Queries;
using its.gamify.api.Features.LearningProgresses.Commands;
using its.gamify.core.Features.LearningProgresses.Queries;
using its.gamify.core.Models.Lessons;
using its.gamify.core.Models.ShareModels;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
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
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterQuery Filter)
        {
            var res = await _mediator.Send(new GetLearningProgressQuery()
            {
                Filter = Filter
            });
            return Ok(res);
        }
    }
}
