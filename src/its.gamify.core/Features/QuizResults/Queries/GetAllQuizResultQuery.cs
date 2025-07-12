using its.gamify.api.Features.Quizzes.Queries;
using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using System.Linq.Expressions;

namespace its.gamify.api.Features.QuizResults.Queries
{
    public class GetAllQuizResultQuery : IRequest<BasePagingResponseModel<QuizResult>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string Search { get; set; } = string.Empty;
        class QueryHandler : IRequestHandler<GetAllQuizResultQuery, BasePagingResponseModel<QuizResult>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<QuizResult>> Handle(GetAllQuizResultQuery request, CancellationToken cancellationToken)
            {

                Expression<Func<QuizResult, bool>>? filter = null;
                /*if (!string.IsNullOrEmpty(request.Search))
                {
                    filter = x => x..Contains(request.Search);
                }*/
                var res = await unitOfWork.QuizResultRepository.ToPagination(request.PageIndex, request.PageSize, filter: filter);

                return new BasePagingResponseModel<QuizResult>(datas: res.Entities, pagination: res.Pagination);
            }

        }

    }
}
