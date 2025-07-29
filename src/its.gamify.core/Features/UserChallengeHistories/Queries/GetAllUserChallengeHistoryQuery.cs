using its.gamify.api.Features.Categories.Queries;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Features.UserChallengeHistories.Queries
{
    public class GetAllUserChallengeHistoryQuery : IRequest<BasePagingResponseModel<UserChallengeHistory>>
    {
        public FilterQuery? Filter { get; set; }
        class QueryHandler : IRequestHandler<GetAllUserChallengeHistoryQuery, BasePagingResponseModel<UserChallengeHistory>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<UserChallengeHistory>> Handle(GetAllUserChallengeHistoryQuery request, CancellationToken cancellationToken)
            {
                var res = await unitOfWork.UserChallengeHistoryRepository.ToDynamicPagination(pageIndex: request.Filter?.Page ?? 0,
                    pageSize: request.Filter?.Limit ?? 10,
                    searchFields: ["ChallengeId","UserId","CreateBy"], searchTerm: request.Filter?.Q ?? string.Empty,
                    sortOrders: request.Filter?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"));
                return BasePagingResponseModel<UserChallengeHistory>.CreateInstance(res.Entities, res.Pagination);


            }
        }

    }
}
