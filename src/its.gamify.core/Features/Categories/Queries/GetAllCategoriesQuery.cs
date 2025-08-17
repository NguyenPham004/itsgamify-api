using System.Linq.Expressions;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using its.gamify.core.Utilities;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace its.gamify.core.Features.Categories.Queries
{
    public class CategoryQuery : FilterQuery
    {
        public bool IsActive { get; set; } = true;

    }
    public class GetAllCategoriesQuery : IRequest<BasePagingResponseModel<Category>>
    {
        public CategoryQuery? Filter { get; set; }
        class QueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<GetAllCategoriesQuery, BasePagingResponseModel<Category>>
        {

            public async Task<BasePagingResponseModel<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                bool checkRole = claimsService.CurrentRole == ROLE.ADMIN || claimsService.CurrentRole == ROLE.TRAININGSTAFF ||
                                claimsService.CurrentRole == ROLE.MANAGER;
                Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? includeFunc = null;
                if (checkRole)
                {
                    includeFunc = x => x.Include(x => x.Courses).Include(x => x.Challenges);
                }

                Expression<Func<Category, bool>> filter = x => x.IsDeleted == !request.Filter!.IsActive;

                var (Pagination, Entities) = await unitOfWork.CategoryRepository.ToDynamicPagination(pageIndex: request.Filter?.Page ?? 0,
                    pageSize: request.Filter?.Limit ?? 10,
                    searchFields: ["Name", "Description"], searchTerm: request.Filter?.Q ?? string.Empty,
                    sortOrders: request.Filter?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"),
                    withDeleted: checkRole,
                    includeFunc: includeFunc,
                    filter: filter

                );
                return BasePagingResponseModel<Category>.CreateInstance(Entities, Pagination);


            }
        }

    }
}
