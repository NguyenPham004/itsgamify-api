using its.gamify.core.Features.Files.Commands;
using its.gamify.core.Features.Files.Queries;
using its.gamify.core.Models.Files;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    public class FilesController(IMediator mediator) : BaseController
    {
        private readonly IMediator mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> PostFile([FromForm] FileCreateModel model)
        {
            var res = await mediator.Send(new UploadFileCommand()
            {
                File = model.File,
            });

            return Ok(res);
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetFile(string fileName)
        {
            var res = await mediator.Send(new GetFileByNameQuery()
            {

                FileName = fileName
            });

            return File(res.Item1, res.Item2, fileName);

        }

        [HttpGet("presigned")]
        public async Task<IActionResult> GetPresignedUrl([FromQuery] string fileName, [FromQuery] int expiryMinutes = 60)
        {
            return Redirect(await mediator.Send(new GetFilePresignedQuery()
            {

                FileName = fileName,
                ExpiryMinutes = expiryMinutes
            }));

        }
    }
}
