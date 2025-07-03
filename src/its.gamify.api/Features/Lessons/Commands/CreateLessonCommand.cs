
using its.gamify.core;
using its.gamify.core.Models.Lessons;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Lessons.Commands
{
    public class CreateLessonCommand : LessonCreateModel, IRequest<Lesson>
    {
        class CommandHandler : IRequestHandler<CreateLessonCommand, Lesson>
        {
            private readonly IMediator mediator;
            private readonly IUnitOfWork _unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork,
                IMediator mediator)
            {
                this.mediator = mediator;
                this._unitOfWork = unitOfWork;
            }
            public async Task<Lesson> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
            {

                Lesson lesson = _unitOfWork.Mapper.Map<Lesson>(request); ;

                await _unitOfWork.LessonRepository.AddAsync(lesson);

                await _unitOfWork.SaveChangesAsync();

                return lesson;
            }
        }
    }
}
