using its.gamify.core;
using its.gamify.core.Models.Practices;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Practices.Commands
{
    public class UpsertPracticeCommand : IRequest<List<PracticeTag>>
    {
        public Guid LessonId { get; set; }
        public List<PracticeUpsertModel> PracticeTags { get; set; } = [];
        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpsertPracticeCommand, List<PracticeTag>>
        {

            public async Task<List<PracticeTag>> Handle(UpsertPracticeCommand request, CancellationToken cancellationToken)
            {
                var existing = await unitOfWork.PracticeTagRepository.WhereAsync(x => x.LessonId == request.LessonId);

                if (existing.Count > 0)
                {
                    unitOfWork.PracticeTagRepository.SoftRemoveRange(existing);
                    await unitOfWork.SaveChangesAsync();
                }


                var pratices = unitOfWork.Mapper.Map<List<PracticeTag>>(request.PracticeTags);
                foreach (var practice in pratices)
                {
                    practice.LessonId = request.LessonId;
                }

                await unitOfWork.PracticeTagRepository.AddRangeAsync(pratices, cancellationToken);
                await unitOfWork.SaveChangesAsync();

                return pratices;
            }
        }
    }
}
