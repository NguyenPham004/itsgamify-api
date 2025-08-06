using its.gamify.api.Features.Questions.Commands;
using its.gamify.api.Features.Questions.Queries;
using its.gamify.api.Features.QuizAnswers.Commands;
using its.gamify.api.Features.QuizAnswers.Queries;
using its.gamify.api.Features.Quizzes.Queries;
using its.gamify.api.Features.QuizResults.Commands;
using its.gamify.api.Features.QuizResults.Queries;
using its.gamify.api.Features.Quizzes.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator mediator = mediator;

        /// <summary>
        /// get quiz by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizById([FromRoute] Guid id)
        {
            return Ok(await mediator.Send(new GetQuizByIdQuery()
            {
                Id = id
            }));
        }

    }
}

