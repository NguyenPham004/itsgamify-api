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
        class CommandHandler : IRequestHandler<UpsertPracticeCommand, List<PracticeTag>>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<List<PracticeTag>> Handle(UpsertPracticeCommand request, CancellationToken cancellationToken)
            {
                var res = new List<PracticeTag>();
                foreach (var practiceTag in request.PracticeTags)
                {
                    var isUpdate = practiceTag.CreateId is not null && practiceTag.CreateId != Guid.Empty;
                    if (isUpdate)
                    {
                        var current = await unitOfWork.PracticeTagRepository.FirstOrDefaultAsync(x => x.Id == practiceTag.CreateId)
                            ?? throw new InvalidOperationException($"Không tìm thấy practice_tag với Id: {practiceTag.CreateId}");
                        unitOfWork.Mapper.Map(practiceTag, current);
                        current.LessonId = request.LessonId;
                        unitOfWork.PracticeTagRepository.Update(current);
                        res.Add(current);
                    }
                    else
                    {
                        var createItem = unitOfWork.Mapper.Map<PracticeTag>(practiceTag);
                        createItem.LessonId = request.LessonId;
                        await unitOfWork.PracticeTagRepository.AddAsync(createItem);
                        res.Add(createItem);
                    }
                    await unitOfWork.SaveChangesAsync();

                }
                return res;
            }
        }
    }
}
