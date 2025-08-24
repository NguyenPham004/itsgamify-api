using its.gamify.core.Features.Badges.Queries;
using its.gamify.core.Models.ShareModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers;

public class BadgeController(IMediator _mediator) : BaseController
{

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllBadge([FromQuery] FilterQuery filter)
    {
        return Ok(await _mediator.Send(new GetAllBadgeByUserIdQuery()
        {
            Filter = filter
        }));

    }
}
