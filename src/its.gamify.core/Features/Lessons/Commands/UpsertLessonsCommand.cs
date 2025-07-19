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
        public List<LessonUpdateModel> Models { get; set; } = [];
        class CommandHandler(
            IUnitOfWork unitOfWork,
            IMediator mediator
        ) : IRequestHandler<UpsertLessonsCommand, List<Lesson>>
        {

            public async Task<List<Lesson>> Handle(UpsertLessonsCommand request, CancellationToken cancellationToken)
            {

                var res = new List<Lesson>();

                foreach (var model in request.Models)
                {
                    Lesson lesson = await unitOfWork.LessonRepository.FirstOrDefaultAsync(x => x.Id == model.Id)
                        ?? throw new Exception("Not found lesson");
                    unitOfWork.Mapper.Map(model, lesson);

                    if (model.Type == LESSON_TYPES.QUIZ && model.QuestionModels?.Count > 0)
                    {
                        lesson.QuizId = await mediator.Send(new UpsertQuestionCommand()
                        {
                            Duration = lesson.DurationInMinutes,
                            QuizId = model.QuizId ?? Guid.Empty,
                            QuestionUpsertModels = model.QuestionModels

                        }, cancellationToken);
                    }
                    unitOfWork.LessonRepository.Update(lesson);
                    await unitOfWork.SaveChangesAsync();

                    if (lesson.Type == LESSON_TYPES.PRACTICE)
                    {
                        lesson.Practices = await mediator.Send(new UpsertPracticeCommand()
                        {
                            LessonId = lesson.Id,
                            PracticeTags = model.Practices!
                        }, cancellationToken);
                    }

                    res.Add(lesson);
                }
                return res;

            }

        }
    }
}
