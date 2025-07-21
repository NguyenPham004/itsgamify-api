using its.gamify.core.Features.EmployeeMetrics;
using its.gamify.core.Models.ShareModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMetricsController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserMetricsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        /// <summary>
        /// Get all user metrics
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterQuery Filter)
        {
            var res = await mediator.Send(new EmployeeMetricQuery()
            {
                Filter = Filter
            });
            return Ok(res);

        }
    }
}
