using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<BasePagingResponseModel<Category>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; } = string.Empty;
        class QueryHandler : IRequestHandler<GetAllCategoriesQuery, BasePagingResponseModel<Category>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                var categories = await unitOfWork.CategoryRepository.ToPagination(request.PageIndex, request.PageSize, false, x => x.Name == request.SearchTerm);
                return new BasePagingResponseModel<Category>(categories.Entities, categories.Pagination);
            }
        }

    }
}
