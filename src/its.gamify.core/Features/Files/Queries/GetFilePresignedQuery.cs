using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Services;
using MediatR;

namespace its.gamify.core.Features.Files.Queries;

public class GetFilePresignedQuery : IRequest<string>
{
    public required string FileName { get; set; }
    public required int ExpiryMinutes { get; set; } = 60;

    class QueryHander(IS3Service _s3Service) : IRequestHandler<GetFilePresignedQuery, string>
    {


        public async Task<string> Handle(GetFilePresignedQuery request, CancellationToken cancellationToken)
        {
            if (!await _s3Service.FileExistsAsync(request.FileName))
            {
                throw new BadRequestException("File not found");
            }

            return await _s3Service.GetPresignedUrlAsync(request.FileName, TimeSpan.FromMinutes(request.ExpiryMinutes));

        }
    }
}
