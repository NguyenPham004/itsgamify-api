using its.gamify.api.Features.Categories.Queries;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Features.Rooms.Queries
{
    public class GetAllRoomQuery : IRequest<BasePagingResponseModel<Room>>
    {
        public FilterQuery? Filter { get; set; }
        class QueryHandler : IRequestHandler<GetAllRoomQuery, BasePagingResponseModel<Room>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<Room>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
            {
                Func<IQueryable<Room>, IIncludableQueryable<Room, object>>? includeFunc =
                x =>
                    x.Include(x => x.Challenge);
                var res = await unitOfWork.RoomRepository.ToDynamicPagination(pageIndex: request.Filter?.Page ?? 0,
                    pageSize: request.Filter?.Limit ?? 10,
                    sortOrders: request.Filter?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"),
                    includeFunc:includeFunc);
                return BasePagingResponseModel<Room>.CreateInstance(res.Entities, res.Pagination);


            }
        }

    }
}
