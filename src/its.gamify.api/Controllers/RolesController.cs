using its.gamify.core.Features.Roles;
using its.gamify.core.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    public class RolesController(IMediator _mediator) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(
                await _mediator.Send(new GetAllRolesQuery())
            );
        }
    }
}
