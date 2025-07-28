using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;


namespace its.gamify.core.Features.UserMetrics;

public class UserMetricFilterQuery : FilterQuery
{
    public Guid DepartmentId { get; set; }
    public Guid QuarterId { get; set; }
}

public class GetAllUserMetricsQuery : IRequest<BasePagingResponseModel<UserMetric>>
{
    public required UserMetricFilterQuery Filter { get; set; }
    class QueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllUserMetricsQuery, BasePagingResponseModel<UserMetric>>
    {
        public async Task<BasePagingResponseModel<UserMetric>> Handle(GetAllUserMetricsQuery request, CancellationToken cancellationToken)
        {

            var (Pagination, Entities) = await unitOfWork.UserMetricRepository.ToPagination(
                pageIndex: request.Filter.Page ?? 0,
                pageSize: request.Filter.Limit ?? 10,
                filter: x => x.QuarterId == request.Filter.QuarterId &&
                             x.User.DepartmentId == request.Filter.DepartmentId &&
                             (string.IsNullOrEmpty(request.Filter.Q) || x.User.FullName.Contains(request.Filter.Q, StringComparison.OrdinalIgnoreCase)),
                cancellationToken: cancellationToken,
                includes: [x => x.User, x => x.User.Department!, x => x.Quarter]
            );

            return new BasePagingResponseModel<UserMetric>(Entities, Pagination);

        }
    }

}