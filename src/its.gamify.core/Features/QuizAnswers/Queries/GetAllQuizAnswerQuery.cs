using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using System.Linq.Expressions;

namespace its.gamify.core.Features.QuizAnswers.Queries
{
    public class GetAllQuizAnswerQuery : IRequest<BasePagingResponseModel<QuizAnswer>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string Search { get; set; } = string.Empty;
        class QueryHandler : IRequestHandler<GetAllQuizAnswerQuery, BasePagingResponseModel<QuizAnswer>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<QuizAnswer>> Handle(GetAllQuizAnswerQuery request, CancellationToken cancellationToken)
            {

                Expression<Func<QuizAnswer, bool>>? filter = null;
                if (!string.IsNullOrEmpty(request.Search))
                {
                    filter = x => x.Answer!.Contains(request.Search);
                }
                var res = await unitOfWork.QuizAnswerRepository.ToPagination(request.PageIndex, request.PageSize, filter: filter, includes: [x => x.QuizResult, x => x.Question]);

                return new BasePagingResponseModel<QuizAnswer>(datas: res.Entities, pagination: res.Pagination);
            }

        }

    }
}
