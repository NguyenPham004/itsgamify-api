using its.gamify.api.Features.CourseCollections.Commands;
using its.gamify.api.Features.CourseCollections.Queries;
using its.gamify.api.Features.CourseMetrics;
using its.gamify.api.Features.CourseParticipations;
using its.gamify.api.Features.CourseParticipations.Commands;
using its.gamify.api.Features.Courses.Commands;
using its.gamify.api.Features.Courses.Queries;
using its.gamify.api.Features.CourseSections.Queries;
using its.gamify.api.Features.LearningMaterials.Commands;
using its.gamify.api.Features.Users.Queries;
using its.gamify.core.Features.LearningMaterials.Queries;
using its.gamify.core.Models.CourseCollections;
using its.gamify.core.Models.Courses;
using its.gamify.core.Models.LearningMaterials;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using MediatR;
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
        /// <summary>
        /// Update course
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CourseUpdateModel updatedItem)
        {
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

        /// <summary>
        /// Delete course section
        /// </summary>
        [HttpDelete("{id}/course-sections/{CourseSectionId}")]
        public async Task<IActionResult> DelCourseSection()
        {
            await Task.CompletedTask;
            return Ok();
        }

        /// <summary>
        /// Get course section by id
        /// </summary>
        [HttpGet("{id}/course-sections")]
        public async Task<IActionResult> GetCourseSectionByCourseId([FromRoute] Guid id)
        {
            return Ok(await mediator.Send(new GetCourseSectionByCourseIdQuery()
            {
                CourseId = id
            }));
        }
        [HttpPost("{id}/learning-materials")]
        public async Task<IActionResult> CreateLearningMaterials([FromForm] LearningMaterialCreateModel command,
            [FromRoute] Guid id)
        {
            return Ok(await mediator.Send(new CreateLearningMaterialCommand()
            {
                CourseId = id,
                Model = command
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
        public async Task<IActionResult> GetCourseParticipation([FromRoute] Guid id,
            [FromQuery] int? limit = 10,
            [FromQuery] int? page = 0)
        {
            var result = await mediator.Send(new GetCourseParticipationByCourse()
            {
                CourseId = id,
                PageIndex = page ?? 0,
                PageSize = limit ?? 10
            });
            return Ok(result);
        }

        /// <summary>
        /// Delete course collection
        /// </summary>
        [HttpDelete("{id}/course-collections/{idCourseCollection}")]
        public async Task<IActionResult> DeleteCourseCollection(Guid id)
        {
            var res = await mediator.Send(new DeleteCourseCollectionCommand()
            {
                Id = id
            });
            return res ? NoContent() : StatusCode(500);
        }
        /// <summary>
        /// Get all course collection
        /// </summary>
        [HttpGet("course-collections/")]
        public async Task<IActionResult> GetAllCourseCollection([FromQuery] FilterQuery query)
        {
            var res = await mediator.Send(new GetAllCourseCollectionQuery()
            {
                filterQuery = query
            });
            return Ok(res);

        }
        /// <summary>
        /// Get course collection by Id
        /// </summary>

        [HttpGet("{id}/course-collections/{idCourseCollection}")]
        public async Task<IActionResult> GetCourseCollectionById([FromRoute] Guid id)
        {
            return Ok(await mediator.Send(new GetCourseCollectionByIdQuery()
            {
                Id = id
            }));

        }
        /// <summary>
        /// Update course collection
        /// </summary>
        [HttpPut("{id}/course-collections/{idCourseCollection}")]
        public async Task<IActionResult> UpdateCourseCollection([FromBody] CourseCollectionUpdateModel updatedItem)
        {
            var result = await mediator.Send(new UpdateCourseCollectionCommand()
            {
                Model = updatedItem
            });
            if (result) return NoContent();
            else return BadRequest();
        }

        /// <summary>
        /// Create course collection
        /// </summary>
        [HttpPost("course-collections/")]
        public async Task<IActionResult> CreateCollection([FromBody] CreateCourseCollectionCommand command,
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        /// <summary>
        /// Get all course metric
        /// </summary>
        [HttpGet("course-metric")]
        public async Task<IActionResult> GetAllCourseMetric([FromQuery] FilterQuery query)
        {
            var res = await mediator.Send(new GetAllCourseMetricQuery()
            {
                filterQuery = query
            });
            return Ok(res);

        }
        /// <summary>
        /// Get course metric by Id
        /// </summary>

        [HttpGet("{id}/course-metric/{idCourseMetric}")]
        public async Task<IActionResult> GetCourseMetricById([FromRoute] Guid id)
        {
            return Ok(await mediator.Send(new GetCourseMetricByIdQuery()
            {
                Id = id
            }));

        }
    }
}
