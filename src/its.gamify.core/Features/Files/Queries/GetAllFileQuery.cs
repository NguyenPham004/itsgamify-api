using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Files.Queries
{
    public class GetAllFileQuery : IRequest<BasePagingResponseModel<FileEntity>>
    {
        public FilterQuery? filterQuery { get; set; }
        class QueryHander : IRequestHandler<GetAllFileQuery, BasePagingResponseModel<FileEntity>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHander(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<FileEntity>> Handle(GetAllFileQuery request,
                CancellationToken cancellationToken)
            {
                var res = await unitOfWork.FileRepository.ToDynamicPagination(pageIndex: request.filterQuery?.Page ?? 0,
                    pageSize: request.filterQuery?.Limit ?? 10);
                return new BasePagingResponseModel<FileEntity>(res.Entities, res.Pagination);
            }
        }
    }
}
