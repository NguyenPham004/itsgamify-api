using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;

namespace its.gamify.api.Features.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<BasePagingResponseModel<Category>>
    {
        public FilterQuery? Filter { get; set; }
        class QueryHandler : IRequestHandler<GetAllCategoriesQuery, BasePagingResponseModel<Category>>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IClaimsService claimsService;
            public QueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
            {
                this.unitOfWork = unitOfWork;
                this.claimsService = claimsService;
            }
            public async Task<BasePagingResponseModel<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                bool checkRole = claimsService.CurrentRole == ROLE.ADMIN || claimsService.CurrentRole == ROLE.TRAININGSTAFF ||
                                claimsService.CurrentRole == ROLE.MANAGER;
                var res = await unitOfWork.CategoryRepository.ToDynamicPagination(pageIndex: request.Filter?.Page ?? 0,
                    pageSize: request.Filter?.Limit ?? 10,
                    searchFields: ["Name"], searchTerm: request.Filter?.Q ?? string.Empty,
                    sortOrders: request.Filter?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"),
                    withDeleted: checkRole);
                return BasePagingResponseModel<Category>.CreateInstance(res.Entities, res.Pagination);


            }
        }

    }
}
