using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace its.gamify.core.Features.CourseParticipations.Queries
{
    public class GetCourseParticipationQuery : IRequest<BasePagingResponseModel<CourseParticipation>>
    {

        public class QueryHandler : IRequestHandler<GetCourseParticipationQuery, BasePagingResponseModel<CourseParticipation>>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IClaimsService claimsService;
            public QueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
            {
                this.unitOfWork = unitOfWork;
                this.claimsService = claimsService;
            }
            public async Task<BasePagingResponseModel<CourseParticipation>> Handle(GetCourseParticipationQuery request, CancellationToken cancellationToken)
            {
                var items = await unitOfWork.CourseParticipationRepository.ToDynamicPagination(
                    pageIndex: 0,
                    pageSize: 3,
                    searchTerm: claimsService.CurrentUser.ToString(), searchFields: ["UserId"],
                    includeFunc: x => x
                        .Include(x => x.User)
                        .Include(x => x.Course!)
                            .ThenInclude(x => x.Category)
                        .Include(x => x.CourseResult!),
                    cancellationToken: cancellationToken);

                return new BasePagingResponseModel<CourseParticipation>(items.Entities, items.Pagination);
            }
        }
    }
}
