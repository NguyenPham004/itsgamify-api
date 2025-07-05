using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using System.Linq.Expressions;

namespace its.gamify.api.Features.Questions.Queries
{
    public class GetAllQuestionQuery : IRequest<BasePagingResponseModel<Question>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string Search { get; set; } = string.Empty;
        class QueryHandler : IRequestHandler<GetAllQuestionQuery, BasePagingResponseModel<Question>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<Question>> Handle(GetAllQuestionQuery request, CancellationToken cancellationToken)
            {

                Expression<Func<Question, bool>>? filter = null;
                if (!string.IsNullOrEmpty(request.Search))
                {
                    filter = x => x.Content.Contains(request.Search);
                }
                var res = await unitOfWork.QuestionRepository.ToPagination(request.PageIndex, request.PageSize, filter: filter, includes: [x => x.Quiz]);

                return new BasePagingResponseModel<Question>(datas: res.Entities, pagination: res.Pagination);
            }

        }

    }
}
