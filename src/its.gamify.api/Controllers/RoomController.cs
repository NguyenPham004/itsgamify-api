using its.gamify.core.Features.Rooms.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    [Authorize]
    public class RoomController : ControllerBase
    {
        private readonly IMediator mediator;
        public RoomController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoomCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);
        }

        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRoomCommand updatedItem)
        {
            var result = await mediator.Send(updatedItem);
            if (result) return NoContent();
            else return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await mediator.Send(new DeleteRoomCommand()
            {
                Id = id
            });
            return res ? NoContent() : StatusCode(500);
        }
    }
}
