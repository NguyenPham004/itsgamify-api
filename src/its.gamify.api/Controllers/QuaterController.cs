using its.gamify.api.Features.Quarters.Commands;
using its.gamify.api.Features.Quarters.Queries;
using its.gamify.core.Features.AvailablesData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuaterController : ControllerBase
    {
        private Ultils data;
        private readonly IMediator mediator;
        public QuaterController(Ultils data,
            IMediator mediator)
        {
            this.mediator = mediator;

        }
        /// <summary>
        /// Get all Quater
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 0,
                                        [FromQuery] int pageSize = 10,
                                        [FromQuery] string searchTerm = "",
                                        [FromQuery] DateTime? dateFrom = null,
                                        [FromQuery] DateTime? dateTo = null)
        {
            var res = await mediator.Send(new GetAllQuarterQuery()
            {
                DateFrom = dateFrom,
                DateTo = dateTo,
                PageIndex = pageNumber,
                PageSize = pageSize,
                SearchTerm = searchTerm
            });
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateQuaterCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);
        }
    }
}
