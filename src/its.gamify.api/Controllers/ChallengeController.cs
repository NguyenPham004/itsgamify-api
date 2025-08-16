using its.gamify.core.Features.Challenges;
using its.gamify.core.Features.Challenges.Commands;
using its.gamify.core.Features.Courses.Commands;
using its.gamify.core.Features.Rooms.Queries;
using its.gamify.core.Models;
using its.gamify.core.Models.Challenges;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    [Authorize]
    public class ChallengeController(IMediator _mediator) : ControllerBase
    {

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] ChallengeQuery query)
        {
            var result = await _mediator.Send(new GetChallengeQuery
            {
                Filter = query
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ChallengeUpdateModel model)
        {
            await _mediator.Send(new UpdateChallengeCommand
            {
                Id = id,
                Model = model
            });
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
        [HttpGet("{id}/rooms")]
        public async Task<IActionResult> GetAllRoom([FromRoute] Guid id, [FromQuery] FilterQuery query)
        {
            var result = await _mediator.Send(new GetAllRoomQuery
            {
                ChallengeId = id,
                Filter = query
            });
            return Ok(result);
        }

        [HttpPut("{id}/re-active")]
        [Authorize(Roles = ROLE.TRAININGSTAFF)]
        public async Task<IActionResult> ReActiveChallenge([FromRoute] Guid id, [FromBody] BaseReActiveModel model)
        {
            return Ok(await _mediator.Send(new ReActiveChallengeCommand()
            {
                Id = id,
                IsActive = model.IsActive
            }));

        }

    }
}
