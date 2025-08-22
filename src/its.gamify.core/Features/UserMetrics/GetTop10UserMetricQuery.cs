using its.gamify.core.Models.ShareModels;
using its.gamify.core.Utilities;
using its.gamify.domains.Entities;
using MediatR;
using System.Linq.Expressions;


namespace its.gamify.core.Features.UserMetrics;

public class GetTop10UserMetricQuery : IRequest<BasePagingResponseModel<UserMetric>>
{
    public required UserMetricFilterQuery Filter { get; set; }
    class QueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetTop10UserMetricQuery, BasePagingResponseModel<UserMetric>>
    {
        public async Task<BasePagingResponseModel<UserMetric>> Handle(GetTop10UserMetricQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<UserMetric, bool>>? filter = x => x.QuarterId == request.Filter.QuarterId &&
                             !x.User.IsDeleted &&
                             x.User.Role!.Name != "ADMIN" &&
                             x.User.Role!.Name != "MANAGER" &&
                             x.User.Role!.Name != "TRAININGSTAFF" &&
                             (string.IsNullOrEmpty(request.Filter.Q) || x.User.FullName.Contains(request.Filter.Q, StringComparison.OrdinalIgnoreCase));
            if(request.Filter.DepartmentId != null)
            {
                Expression<Func<UserMetric, bool>>? filterDepar = x => x.User.Department!.Id == request.Filter.DepartmentId;
                filter = filter != null ? FilterCustom.CombineFilters(filter, filterDepar) : filterDepar;
            }
            var (Pagination, Entities) = await unitOfWork.UserMetricRepository.ToPagination(
                pageIndex: request.Filter.Page ?? 0,
                pageSize: request.Filter.Limit ?? 10,
                filter: filter,
                cancellationToken: cancellationToken,
                orderByList: [(x => x.PointInQuarter, true)],
                includes: [x => x.User, x => x.User.Department!, x => x.Quarter]
            );

            return new BasePagingResponseModel<UserMetric>(Entities, Pagination);

        }
    }

}