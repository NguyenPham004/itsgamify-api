using its.gamify.api.Extensions;
using its.gamify.api.Features.Departments.Commands;
using its.gamify.api.Features.Departments.Queries;
using its.gamify.core.Models.Departments;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace its.gamify.api.Controllers
{

    [Route("api/[controller]s")]
    [ApiController]
    public class DepartmentController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator mediator = mediator;

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await mediator.Send(new DeleteDepartmentCommand
            {
                Id = id
            });
            return NoContent();
        }

        [HttpGet]
        [ProcessOrderBy]
        public async Task<IActionResult> GetAll([FromQuery] FilterQuery filter)
        {
            return Ok(await mediator.Send(new GetAllDepartmentQuery()
            {
                Filter = filter
            }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] DepartmentUpdateModel updatedItem)
        {
            await mediator.Send(new UpdateDepartmentCommand
            {
                Id = id,
                Model = updatedItem
            });
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentCreateModel createItem)
        {
            return Ok(await mediator.Send(new CreateDepartmentCommand
            {
                Model = createItem
            }));
        }



        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await mediator.Send(new GetDepartmentByIdQuery()
            {
                Id = id
            }));
        }
        /// <summary>
        /// Delete list Department 
        /// </summary>
        [HttpDelete("delete-range")]
        public async Task<IActionResult> DeleteRange(List<Guid> ids)
        {
            var res = await mediator.Send(new DeleteRangeDepartmentCommand()
            {
                Ids = ids
            });
            return res ? NoContent() : StatusCode(500);
        }
    }
}
