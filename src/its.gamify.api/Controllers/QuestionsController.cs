using its.gamify.core.Features.Questions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    public class QuestionsController(IMediator _mediator) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QuestionFilterQuery query)
        {
            return Ok(
                await _mediator.Send(new GetAllQuestionQuery
                {
                    FilterQuery = query
                })
            );
        }
    }
}
