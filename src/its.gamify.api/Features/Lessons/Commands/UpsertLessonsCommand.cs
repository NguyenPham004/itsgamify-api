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
                foreach (var model in request.Models)
                {
                    Lesson lesson = await unitOfWork.LessonRepository.FirstOrDefaultAsync(x => x.Id == model.Id)
                        ?? throw new Exception("Not found lesson");
                    unitOfWork.Mapper.Map(model, lesson);
                    unitOfWork.LessonRepository.Update(lesson);
                    await unitOfWork.SaveChangesAsync();
                    res.Add(lesson);

                    if (lesson.Type == LESSON_TYPES.QUIZ && model.QuestionModels?.Count > 0)
                    {
                        var questions = await mediator.Send(new UpsertQuestionCommand()
                        {
                            LessonId = lesson.Id,
                            QuestionUpsertModels = model.QuestionModels

                        }, cancellationToken);
                    }
                }
                return res;

            }

        }
    }
}
