using System.Linq.Expressions;
using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Models.Users;
using its.gamify.core.Utilities;
using its.gamify.domains.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace its.gamify.api.Features.Users.Queries
{
    public class UserFilterQuery : FilterQuery
    {
        public string? Departments { get; set; } = string.Empty;
        public Guid? RoleId { get; set; } = null;
    }

    public class GetAllUserQuery : IRequest<BasePagingResponseModel<UserViewModel>>
    {

        public required UserFilterQuery FilterQuery { get; set; }

        class QueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllUserQuery, BasePagingResponseModel<UserViewModel>>
        {
            public async Task<BasePagingResponseModel<UserViewModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {

                Expression<Func<User, bool>>? filter = null;
                if (!string.IsNullOrEmpty(request.FilterQuery!.Departments))
                {
                    var departments = JsonConvert.DeserializeObject<List<Guid>>(request.FilterQuery!.Departments!);
                    if (departments != null && departments.Count != 0)
                    {
                        Expression<Func<User, bool>> filter_dept = x => departments != null && departments.Count != 0 && departments.Contains(x.DepartmentId!.Value);
                        filter = filter != null ? FilterCustom.CombineFilters(filter, filter_dept) : filter_dept;
                    }
                }

                if (request.FilterQuery!.RoleId != null)
                {
                    Expression<Func<User, bool>> filter_role = x => x.RoleId == request.FilterQuery.RoleId;
                    filter = filter != null ? FilterCustom.CombineFilters(filter, filter_role) : filter_role;
                }

                var (Pagination, Entities) = await unitOfWork.UserRepository.ToDynamicPagination(
                    pageIndex: request.FilterQuery!.Page ?? 0,
                    pageSize: request.FilterQuery.Limit ?? 0,
                    filter: filter,
                    searchFields: ["FullName", "Email"],
                    searchTerm: request.FilterQuery.Q,
                    sortOrders: request.FilterQuery?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC") ?? [],
                    includeFunc: x => x.Include(x => x.Role!).Include(x => x.Department!)
                );
                var resModel = unitOfWork.Mapper.Map<List<UserViewModel>>(Entities);
                return new BasePagingResponseModel<UserViewModel>(datas: resModel, pagination: Pagination);
            }
        }
    }
}
