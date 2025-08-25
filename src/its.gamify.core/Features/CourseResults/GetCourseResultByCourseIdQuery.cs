using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.CourseResults
{
    public class GetCourseResultByCourseIdQuery : IRequest<CourseResult>
    {
        public Guid CourseId { get; set; }
        public class QueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<GetCourseResultByCourseIdQuery, CourseResult>
        {
            public async Task<CourseResult> Handle(GetCourseResultByCourseIdQuery request, CancellationToken cancellationToken)
            {
                return await unitOfWork.CourseResultRepository
                    .FirstOrDefaultAsync(
                        x => x.CourseId == request.CourseId && x.UserId == claimsService.CurrentUser,
                        cancellationToken: cancellationToken,
                        includes: [x => x.User, x => x.Course, x => x.CourseParticipation]
                    ) ?? throw new BadRequestException("Bạn chưa hoàn thành khóa học!");
            }
        }
    }
}
