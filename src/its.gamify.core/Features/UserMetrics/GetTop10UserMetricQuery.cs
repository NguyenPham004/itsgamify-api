using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;


namespace its.gamify.core.Features.UserMetrics;

public class GetTop10UserMetricQuery : IRequest<BasePagingResponseModel<UserMetric>>
{
    public required UserMetricFilterQuery Filter { get; set; }
    class QueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetTop10UserMetricQuery, BasePagingResponseModel<UserMetric>>
    {
        public async Task<BasePagingResponseModel<UserMetric>> Handle(GetTop10UserMetricQuery request, CancellationToken cancellationToken)
        {

            var (Pagination, Entities) = await unitOfWork.UserMetricRepository.ToPagination(
                pageIndex: request.Filter.Page ?? 0,
                pageSize: request.Filter.Limit ?? 10,
                filter: x => x.QuarterId == request.Filter.QuarterId &&
                             x.User.DepartmentId == request.Filter.DepartmentId &&
                             (string.IsNullOrEmpty(request.Filter.Q) || x.User.FullName.Contains(request.Filter.Q, StringComparison.OrdinalIgnoreCase)),
                cancellationToken: cancellationToken,
                orderByList: [(x => x.PointInQuarter, true)],
                includes: [x => x.User, x => x.User.Department!, x => x.Quarter]
            );

            return new BasePagingResponseModel<UserMetric>(Entities, Pagination);

        }
    }

}