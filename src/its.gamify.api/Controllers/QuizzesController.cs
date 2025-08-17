using its.gamify.core.Features.Quizzes.Queries;
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

