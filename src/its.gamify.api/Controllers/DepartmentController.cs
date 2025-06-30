using its.gamify.api.Features.Departments.Commands;
using its.gamify.api.Features.Departments.Queries;
using its.gamify.core.Models.Departments;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace its.gamify.api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMediator mediator;
        public DepartmentController(IDepartmentService DepartmentService, IMediator mediator)
        {
            _departmentService = DepartmentService;
            this.mediator = mediator;
        }
        /// <summary>
        /// Delete Department
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _departmentService.Delete(id);
            if (result) return Ok("Delete Successfully");
            else return BadRequest("Deleted Failed");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRage([FromBody] List<Guid> ids)
        {
            var result = await _departmentService.DeleteRange(ids);
            return NoContent();
        }

        /// <summary>
        /// Get all Department
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterQuery filter)
        {
            var res = await mediator.Send(new GetAllDepartmentQuery()
            {
                Filter = filter
            });
            return Ok(res);

        }

        /// <summary>
        /// Update department
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DepartmentUpdateModel updatedItem)
        {
            var result = await _departmentService.Update(updatedItem);
            if (result) return NoContent();
            else return BadRequest();
        }

        /// <summary>
        /// Create department
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentCreateModel createItem)
        {
            /*createdepartmentDTO.File = formFile;*/
            var result = await _departmentService.Create(createItem);
            if (result is null)
            {
                return BadRequest("Can not create Department");

            }
            else return Ok(result);
        }


        /// <summary>
        /// Get department by Id
        /// </summary>
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
