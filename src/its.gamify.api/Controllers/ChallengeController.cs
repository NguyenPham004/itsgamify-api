using its.gamify.core.Features.Challenges.Commands;
using its.gamify.core.Features.Challenges.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class ChallengeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ChallengeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetChallengeQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetChallengeByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateChallengeCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateChallengeCommand updatedItem)
        {
            var result = await _mediator.Send(updatedItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await _mediator.Send(new DeleteChallengeCommand()
            {
                Id = id
            });
            return res ? NoContent() : StatusCode(500);
        }
    }
}
