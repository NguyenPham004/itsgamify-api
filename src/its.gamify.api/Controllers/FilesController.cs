// using its.gamify.core.Models.Files;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;

// namespace its.gamify.api.Controllers
// {
//     public class FilesController : BaseController
//     {
//         private readonly IMediator mediator;
//         public FilesController(IMediator mediator)
//         {
//             this.mediator = mediator;
//         }
//         /// <summary>
//         /// Post file
//         /// </summary>
//         /// <returns></returns>
//         [HttpPost]
//         public async Task<IActionResult> PostFile([FromForm] FileUploadRequestModel model)
//         {
//             var res = await mediator.Send(model);
//             return Ok(res);
//         }
//     }
// }
