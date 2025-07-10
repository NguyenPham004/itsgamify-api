using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using System.Linq.Expressions;

namespace its.gamify.api.Features.Quizes.Queries
{
    public class GetAllQuizQuery : IRequest<BasePagingResponseModel<Quiz>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string Search { get; set; } = string.Empty;
        class QueryHandler : IRequestHandler<GetAllQuizQuery, BasePagingResponseModel<Quiz>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<Quiz>> Handle(GetAllQuizQuery request, CancellationToken cancellationToken)
            {

                Expression<Func<Quiz, bool>>? filter = null;
                if (!string.IsNullOrEmpty(request.Search))
                {
                    filter = x =>
                             // x.LessonId.Equals(Guid.Parse(request.Search)) ||
                             x.ChallengIdId.Equals(Guid.Parse(request.Search));
                }
                var res = await unitOfWork.QuizRepository.ToPagination(request.PageIndex, request.PageSize, filter: filter);

                return new BasePagingResponseModel<Quiz>(datas: res.Entities, pagination: res.Pagination);
            }

        }

    }
}
