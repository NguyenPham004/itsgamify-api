using its.gamify.api.Features.CourseParticipations;
using its.gamify.api.Features.CourseParticipations.Commands;
using its.gamify.api.Features.Courses.Commands;
using its.gamify.api.Features.Courses.Queries;
using its.gamify.api.Features.CourseSections.Queries;
using its.gamify.api.Features.LearningMaterials.Commands;
using its.gamify.api.Features.Users.Queries;
using its.gamify.core.Features.LearningMaterials.Queries;
using its.gamify.core.Models.Courses;
using its.gamify.core.Models.LearningMaterials;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMediator mediator;
        public CourseController(ICourseService courseService, IMediator mediator)
        {
            _courseService = courseService;
            this.mediator = mediator;
        }
        /// <summary>
        /// Delete course
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _courseService.Delete(id);
            if (result) return Ok("Delete Successfully");
            else return BadRequest("Deleted Failed");
        }


        /// <summary>
        /// Get all course
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterQuery query)
        {
            var res = await mediator.Send(new GetAllCourseQuery()
            {
                filterQuery = query
            });
            return Ok(res);

        }
        /// <summary>
        /// Get course by Id
        /// </summary>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok(await mediator.Send(new GetCourseByIdQuery()
            {
                Id = id
            }));

        }

        [HttpGet("{id}/course-sections")]
        public async Task<IActionResult> GetCourseSectionByCourseId([FromRoute] Guid id)
        {
            return Ok(await mediator.Send(new GetCourseSectionByCourseIdQuery()
            {
                CourseId = id
            }));
        }


        [HttpGet("{id}/learning-materials")]
        public async Task<IActionResult> GetLearningMaterials([FromRoute] Guid id,
            [FromQuery] int pageSize = 10,
            [FromQuery] int pageIndex = 0)
        {
            return Ok(await mediator.Send(new GetLearningMaterialQuery()
            {
                CourseId = id,
                PageIndex = pageIndex,
                PageSize = pageSize,
            }));
        }
        /// <summary>
        /// Update course
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,
            [FromBody] CourseUpdateModel updatedItem)
        {
            updatedItem.Id = id;
            var result = await mediator.Send(new UpdateCourseCommand()
            {
                Model = updatedItem
            });
            if (result) return NoContent();
            else return BadRequest();
        }

        /// <summary>
        /// Create course
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseCommand command,
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{id}/course-participations")]
        public async Task<IActionResult> JoinCourse([FromRoute] Guid id)
        {
            var courseParticipation = await mediator.Send(new JoinCourseCommand()
            {
                Id = id
            });
            return Ok(courseParticipation);
        }


        [HttpGet("{id}/course-participations")]
        [Authorize]
        public async Task<IActionResult> GetCourseParticipation([FromRoute] Guid id)
        {
            var result = await mediator.Send(new GetCourseParticipationByCourse()
            {
                CourseId = id,
                PageIndex = 0,
                PageSize = 10
            });
            return Ok(result);
        }


    }
}