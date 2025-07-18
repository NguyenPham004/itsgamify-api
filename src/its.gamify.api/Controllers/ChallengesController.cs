// using its.gamify.core.Features.Challenges.Queries;
// using its.gamify.domains.Entities;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;
using its.gamify.core.Features.Challenges.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// namespace its.gamify.api.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class ChallengesController : ControllerBase
//     {
//         private readonly IMediator _mediator;
//         public ChallengesController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         [HttpGet]
//         public async Task<IActionResult> GetAll([FromQuery] GetChallengeQuery query)
//         {
//             var result = await _mediator.Send(query);
//             if (result == null || result.Datas == null || !result.Datas.Any())
//                 throw new InvalidOperationException("Danh sách Challenge trống");
//             return Ok(result);
//         }

//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetById(Guid id)
//         {
//             var result = await _mediator.Send(new GetChallengeByIdQuery { Id = id });
//             if (result == null)
//                 throw new InvalidOperationException($"Không tìm thấy Challenge với id: {id}");
//             return Ok(result);
//         }
//     }
// }
