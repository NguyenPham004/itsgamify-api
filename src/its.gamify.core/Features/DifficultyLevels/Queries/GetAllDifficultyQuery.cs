using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.DifficultyLevels.Queries
{
    public class GetAllDifficultyQuery : IRequest<BasePagingResponseModel<Difficulty>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        class QueryHandler : IRequestHandler<GetAllDifficultyQuery, BasePagingResponseModel<Difficulty>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<Difficulty>> Handle(GetAllDifficultyQuery request, CancellationToken cancellationToken)
            {
                var res = await unitOfWork.DifficultyRepository.ToPagination(request.PageIndex,
                    request.PageSize);
                return new BasePagingResponseModel<Difficulty>(res.Entities, res.Pagination);
            }
        }
    }
}
