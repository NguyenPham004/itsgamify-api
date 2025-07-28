using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace its.gamify.core.Features.CourseParticipations.Queries
{

    public class ParticipationQuery : FilterQuery
    {
        public string? Status { get; set; } = COURSE_PARTICIPATION_STATUS.ENROLLED;
    }

    public class GetCourseParticipationQuery : IRequest<BasePagingResponseModel<CourseParticipation>>
    {
        public required ParticipationQuery ParticipationQuery { get; set; }

        public class QueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<GetCourseParticipationQuery, BasePagingResponseModel<CourseParticipation>>
        {
            public async Task<BasePagingResponseModel<CourseParticipation>> Handle(GetCourseParticipationQuery request, CancellationToken cancellationToken)
            {
                var user = await unitOfWork.UserRepository.GetByIdAsync(claimsService.CurrentUser) ?? throw new BadRequestException("Không tìm thấy người dùng!");
                var (Pagination, Entities) = await unitOfWork.CourseParticipationRepository.ToDynamicPagination(
                    pageIndex: request.ParticipationQuery.Page ?? 0,
                    pageSize: request.ParticipationQuery.Limit ?? 10,
                    filter: x => x.UserId == claimsService.CurrentUser && x.Status == request.ParticipationQuery.Status,
                    includeFunc: x => x
                        .Include(x => x.User)
                        .Include(x => x.Course!)
                            .ThenInclude(x => x.Category)
                        .Include(x => x.CourseResult!),
                    cancellationToken: cancellationToken);

                return new BasePagingResponseModel<CourseParticipation>(Entities, Pagination);
            }
        }
    }
}
