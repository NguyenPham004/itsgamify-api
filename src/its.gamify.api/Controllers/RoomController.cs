using its.gamify.core.Features.Rooms.Commands;
using its.gamify.core.Features.Rooms.Queries;
using its.gamify.core.Models.Rooms;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    [Authorize]
    public class RoomController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator mediator = mediator;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await mediator.Send(new GetRoomByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoomCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RoomUpdateModel model)
        {
            await mediator.Send(new UpdateRoomCommand
            {
                Id = id,
                Model = model
            });
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await mediator.Send(new DeleteRoomCommand()
            {
                Id = id
            });
            return NoContent();
        }
    }
}
