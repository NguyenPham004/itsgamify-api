using System.Linq.Expressions;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace its.gamify.core.Features.Badges.Queries;

public class GetAllBadgeByUserIdQuery : IRequest<BasePagingResponseModel<Badge>>
{
    public FilterQuery? Filter { get; set; }
    class QueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<GetAllBadgeByUserIdQuery, BasePagingResponseModel<Badge>>
    {

        public async Task<BasePagingResponseModel<Badge>> Handle(GetAllBadgeByUserIdQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Badge, bool>> filter = x => x.UserId == claimsService.CurrentUser;

            var (Pagination, Entities) = await unitOfWork.BadgeRepository.ToDynamicPagination(pageIndex: request.Filter?.Page ?? 0,
                pageSize: request.Filter?.Limit ?? 10,
                searchFields: ["Name", "Description"], searchTerm: request.Filter?.Q ?? string.Empty,
                sortOrders: request.Filter?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"),
                filter: filter,
                includeFunc: x => x.Include(x => x.User)

            );
            return BasePagingResponseModel<Badge>.CreateInstance(Entities, Pagination);


        }
    }

}
