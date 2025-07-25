using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace its.gamify.core.Features.CourseParticipations.Queries
{
    public class GetCourseParticipationQuery : IRequest<BasePagingResponseModel<CourseParticipation>>
    {

        public class QueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<GetCourseParticipationQuery, BasePagingResponseModel<CourseParticipation>>
        {
            private readonly IUnitOfWork unitOfWork = unitOfWork;
            private readonly IClaimsService claimsService = claimsService;

            public async Task<BasePagingResponseModel<CourseParticipation>> Handle(GetCourseParticipationQuery request, CancellationToken cancellationToken)
            {
                var user = await unitOfWork.UserRepository.GetByIdAsync(claimsService.CurrentUser) ?? throw new BadRequestException("Không tìm thấy người dùng!");
                var (Pagination, Entities) = await unitOfWork.CourseParticipationRepository.ToDynamicPagination(
                    pageIndex: 0,
                    pageSize: 3,
                    filter: x => x.UserId == claimsService.CurrentUser,
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
