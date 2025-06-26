using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.CourseParticipations
{
    public class GetCourseParticipationByCourse : IRequest<BasePagingResponseModel<CourseParticipation>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Guid CourseId { get; set; }
        class QueryHandler : IRequestHandler<GetCourseParticipationByCourse, BasePagingResponseModel<CourseParticipation>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<CourseParticipation>> Handle(GetCourseParticipationByCourse request, CancellationToken cancellationToken)
            {
                var res = await unitOfWork.CourseParticipationRepository.ToPagination(pageIndex: request.PageIndex, pageSize: request.PageSize,
                     filter: x => x.CourseId == request.CourseId, cancellationToken: cancellationToken,
                    includes: [x => x.Course, x => x.User]);
                return new BasePagingResponseModel<CourseParticipation>(res.Entities, res.Pagination);
            }
        }

    }
}
