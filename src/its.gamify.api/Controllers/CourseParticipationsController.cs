using its.gamify.api.Features.CourseParticipations;
using its.gamify.api.Features.Courses.Queries;
using its.gamify.core.Features.CourseParticipations.Queries;
using its.gamify.core.Models.ShareModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [ApiController]
    [Route("api/course-participations")]
    public class CourseParticipationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CourseParticipationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetCourseParticipationQuery());
            if (result == null || result.Datas == null || result.Datas.Count == 0)
                return Ok();
            // throw new InvalidOperationException("Danh sách CourseParticipation trống");
            return Ok(result);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetCourseParticipation([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetCourseParticipationByCourse()
            {
                CourseId = id,
                PageIndex = 0,
                PageSize = 10
            });
            return Ok(result);
        }

        [HttpGet("classify-course")]
        [Authorize]
        public async Task<IActionResult> ClassifyCourse([FromQuery] CourseQuery query)
        {
            var result = await _mediator.Send(new ClassifyCourseQuery()
            {
                FilterQuery = query,
            });
            return Ok(result);
        }
        /*[HttpGet("category")]
        [Authorize]
        public async Task<IActionResult> GetCourseParticipatedByCategory([FromQuery] FilterQuery query, [FromQuery] Guid categoryId)
        {
            var result = await _mediator.Send(new GetCourseByCategoryQuery()
            {
                FilterQuery = query,
                CategoryId = categoryId
            });
            return Ok(result);
        }*/
    }
}
