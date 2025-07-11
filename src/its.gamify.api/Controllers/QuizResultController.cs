using its.gamify.api.Features.QuizResults.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using its.gamify.core.Models.QuizResults;

namespace its.gamify.api.Controllers
{
    [Route("api/quiz-results")]
    [ApiController]
    public class QuizResultController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator mediator = mediator;

        /// <summary>
        /// Create quiz result
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateQuizResult([FromBody] QuizResultCreateModel model,
            [FromServices] IMediator mediator)
        {
            /*createcourseDTO.File = formFile;*/

            var result = await mediator.Send(new CreateQuizResultCommand
            {
                Model = model
            });
            return Ok(result);
        }

    }
}

