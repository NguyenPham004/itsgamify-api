using its.gamify.api.Features.Categories.Commands;
using its.gamify.core.Features.Categories.Commands;
using its.gamify.core.Features.Categories.Queries;
using its.gamify.core.Models;
using its.gamify.core.Models.Categories;
using its.gamify.domains.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(IMediator mediator) : ControllerBase
    {

        /// <summary>
        /// Get all Category
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CategoryQuery Filter)
        {
            var res = await mediator.Send(new GetAllCategoriesQuery()
            {
                Filter = Filter
            });
            return Ok(res);

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);
        }

        /// <summary>
        /// Update category
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CategoryUpdateModel model)
        {
            var result = await mediator.Send(new UpdateCategoryCommand
            {
                Id = id,
                Model = model
            });
            if (result) return NoContent();
            else return BadRequest();
        }

        /// <summary>
        /// Delete category
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await mediator.Send(new DeleteCategoryCommand()
            {
                Id = id
            });
            return res ? NoContent() : StatusCode(500);
        }
        /// <summary>
        /// Delete list Category
        /// </summary>
        [HttpDelete("delete-range")]
        public async Task<IActionResult> DeleteRange(List<Guid> ids)
        {
            var res = await mediator.Send(new DeleteRangeCategoryCommand()
            {
                Ids = ids
            });
            return res ? NoContent() : StatusCode(500);
        }

        [HttpPut("{id}/re-active")]
        [Authorize(Roles = ROLE.ADMIN)]
        public async Task<IActionResult> ReActiveChallenge([FromRoute] Guid id, [FromBody] BaseReActiveModel model)
        {
            return Ok(await mediator.Send(new ReActiveCategoryCommand()
            {
                Id = id,
                IsActive = model.IsActive
            }));

        }
    }
}
