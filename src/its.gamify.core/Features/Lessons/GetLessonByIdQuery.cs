using System.Linq.Expressions;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.Lessons.Queries
{
    public class GetLessonByIdQuery : IRequest<Lesson>
    {
        public Guid Id { get; set; }
        public class QueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetLessonByIdQuery, Lesson>
        {

            public async Task<Lesson> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
            {
                Expression<Func<Lesson, object>>[] includes = [
                    x => x.Quiz!,
                    x => x.Quiz!.Questions.Where(x=>!x.IsDeleted),
                    x=>x.Practices.Where(x=>!x.IsDeleted)
                ];

                return await _unitOfWork
                    .LessonRepository
                    .GetByIdAsync(
                        request.Id,
                        cancellationToken: cancellationToken,
                        includes: includes
                    ) ?? throw new Exception("can not find lesson");
            }
        }
    }
}
