using its.gamify.api.Features.Practices.Commands;
using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using its.gamify.core.Models.Lessons;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;

namespace its.gamify.api.Features.Lessons.Commands
{
    public class UpsertLessonsCommand : IRequest<List<Lesson>>
    {
        public Guid CourseSectionId { get; set; }
        public List<LessonCreateModel> Models { get; set; } = [];
        class CommandHandler : IRequestHandler<UpsertLessonsCommand, List<Lesson>>
        {
            private readonly IMediator mediator;
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork,
                IMediator mediator)
            {
                this.mediator = mediator;
                this.unitOfWork = unitOfWork;
            }
            public async Task<List<Lesson>> Handle(UpsertLessonsCommand request, CancellationToken cancellationToken)
            {
                var res = new List<Lesson>();
                foreach (var lesson in request.Models)
                {
                    var isUpdate = lesson.CreateId != null;
                    Lesson? current = null;
                    if (isUpdate)
                    {
                        current = await unitOfWork.LessonRepository.FirstOrDefaultAsync(x => x.Id == lesson.CreateId);
                        unitOfWork.Mapper.Map(lesson, current);
                    }

                    var entity = isUpdate ? current : unitOfWork.Mapper.Map<Lesson>(lesson);
                    if (isUpdate)
                    {
                        unitOfWork.LessonRepository.Update(entity!);
                    }
                    else
                    {
                        entity!.CourseSectionId = request.CourseSectionId;
                        await unitOfWork.LessonRepository.AddAsync(entity!);
                    }
                    await unitOfWork.SaveChangesAsync();
                    if (lesson.QuestionModels?.Count > 0)
                    {
                        var questions = await mediator.Send(new UpsertQuestionCommand()
                        {
                            LessonId = entity!.Id,
                            QuestionUpsertModels = lesson.QuestionModels

                        });
                        entity.Quizzes = [questions.First().Quiz];
                    }
                    if (lesson.Type == LessonType.PRACTICE.ToString()
                        && lesson.Practices?.Count > 0)
                    {
                        var practices = await mediator.Send(new UpsertPracticeCommand()
                        {
                            LessonId = entity?.Id ?? Guid.Empty,
                            PracticeTags = lesson.Practices
                        });
                        entity!.Practices = practices;
                    }
                    res.Add(entity!);
                }
                return res;
            }
        }
    }
}
