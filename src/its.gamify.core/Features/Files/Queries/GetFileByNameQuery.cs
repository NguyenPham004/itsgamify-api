using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Services;
using MediatR;

namespace its.gamify.core.Features.Files.Queries;

public class GetFileByNameQuery : IRequest<(Stream, string)>
{
    public required string FileName { get; set; }
    class QueryHander(IS3Service _s3Service) : IRequestHandler<GetFileByNameQuery, (Stream, string)>
    {

        private static string GetContentType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return extension switch
            {
                ".mp4" => "video/mp4",
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".pdf" => "application/pdf",
                _ => "application/octet-stream"
            };
        }
        public async Task<(Stream, string)> Handle(GetFileByNameQuery request, CancellationToken cancellationToken)
        {
            // Kiểm tra file có tồn tại không
            if (!await _s3Service.FileExistsAsync(request.FileName))
            {
                throw new BadRequestException("File not found");
            }

            // Lấy file stream
            var fileStream = await _s3Service.GetFileAsync(request.FileName);

            // Xác định content type
            var contentType = GetContentType(request.FileName);

            return (fileStream, contentType);

        }
    }
}
