using Amazon.S3.Model;
using its.gamify.core.Features.Files.Commands;
using its.gamify.core.Features.Files.Queries;
using its.gamify.core.Models.Files;
using its.gamify.core.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    public class FilesController(IMediator mediator, IS3Service s3Service) : BaseController
    {
        private readonly IMediator mediator = mediator;
        private readonly IS3Service _s3Service = s3Service;

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


        [HttpPost("s3/initiate-upload")]
        public async Task<IActionResult> InitiateUpload(InitiateMultipartUploadModel model)
        {
            var uploadId = await _s3Service.InitiateMultipartUploadAsync(model);
            return Ok(uploadId);
        }

        [HttpPost("s3/generate-presigned-url")]
        public async Task<IActionResult> GeneratePresignedUrl(GeneratePresignedUrlModel model)
        {
            var url = await _s3Service.GeneratePresignedUrlForPartAsync(model);
            return Ok(url);
        }

        [HttpPost("s3/complete-upload")]
        public async Task<IActionResult> CompleteUpload(CompleteMultipartUploadModel model)
        {

            return Ok(await _s3Service.CompleteMultipartUploadAsync(model));
        }
    }
}
