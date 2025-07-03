using its.gamify.core;
using its.gamify.core.Models.Departments;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace its.gamify.api.Features.Departments.Queries
{
    public class GetAllDepartmentQuery : IRequest<BasePagingResponseModel<DepartmentViewModel>>
    {
        public FilterQuery Filter { get; set; }

        class QueryHandler : IRequestHandler<GetAllDepartmentQuery, BasePagingResponseModel<DepartmentViewModel>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<DepartmentViewModel>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
            {

                var res = await unitOfWork.DepartmentRepository.ToDynamicPagination(
                    pageIndex: request.Filter.Page ?? 0,
                    pageSize: request.Filter.Limit ?? 0,
                    searchFields: ["Description", "Name"],
                    searchTerm: request.Filter.Q,
                    sortOrders: request.Filter?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC") ?? [],
                    includeFunc: x => x.Include(d => d.Users!)
                        .ThenInclude(u => u!.Role!)
                        .Include(x => x.Courses!));
                var models = unitOfWork.Mapper.Map<List<DepartmentViewModel>>(res.Entities);

                return new BasePagingResponseModel<DepartmentViewModel>(datas: models, pagination: res.Pagination);
            }

        }

    }
}
