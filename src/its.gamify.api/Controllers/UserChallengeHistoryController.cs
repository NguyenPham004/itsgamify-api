using its.gamify.api.Features.Categories.Commands;
using its.gamify.api.Features.Categories.Queries;
using its.gamify.core.Features.Challenges.Commands;
using its.gamify.core.Features.UserChallengeHistories.Commands;
using its.gamify.core.Models.ShareModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/challenge-histories")]
    [ApiController]
    public class ChallengeHistory : ControllerBase
    {
        private readonly IMediator mediator;
        public ChallengeHistory(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateUserChallengeHistoryCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);
        }

    }
}
