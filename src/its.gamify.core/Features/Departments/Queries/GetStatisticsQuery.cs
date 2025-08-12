using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace its.gamify.core.Features.Departments.Queries;

public class StatisticFilter : FilterQuery
{
    public Guid QuarterId { get; set; }

}

public class GetStatisticsQuery : IRequest<BasePagingResponseModel<Department>>
{
    public required StatisticFilter Filter { get; set; }

    class QueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetStatisticsQuery, BasePagingResponseModel<Department>>
    {

        public async Task<BasePagingResponseModel<Department>> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
        {

            var (Pagination, Entities) = await unitOfWork.DepartmentRepository.ToDynamicPagination(
                pageIndex: request.Filter!.Page ?? 0,
                pageSize: request.Filter.Limit ?? 0,
                searchFields: ["Description", "Name"],
                searchTerm: request.Filter.Q,
                sortOrders: request.Filter?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC") ?? [],
                includeFunc: x => x.Include(d => d.Users!.Where(x => !x.IsDeleted))
                                        .ThenInclude(u => u!.Role!)
                                    .Include(x => x.Users!.Where(x => !x.IsDeleted))
                                        .ThenInclude(u => u!.UserMetrics!.Where(x => x.QuarterId == request.Filter!.QuarterId))
                        );

            return new BasePagingResponseModel<Department>(datas: Entities, pagination: Pagination);
        }

    }

}

