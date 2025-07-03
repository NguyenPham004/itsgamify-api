using its.gamify.api.Features.Lessons.Commands;
using its.gamify.core;
using its.gamify.core.IntegrationServices.Interfaces;
using its.gamify.core.Models.CourseSections;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.CourseSections.Commands
{
    public class UpsertCourseSectionCommand : IRequest<CourseSection>
    {
        public required CourseSectionUpdateModel Model { get; set; }
        public required Guid SectionId { get; set; }
        class CommandHandler : IRequestHandler<UpsertCourseSectionCommand, CourseSection>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IFirebaseService firebaseSerivce;
            private readonly IMediator mediator;
            public CommandHandler(IUnitOfWork unitOfWork,
                IFirebaseService firebaseService,
                IMediator mediator)
            {
                this.mediator = mediator;
                this.firebaseSerivce = firebaseService;
                this._unitOfWork = unitOfWork;
            }
            public async Task<CourseSection> Handle(UpsertCourseSectionCommand request, CancellationToken cancellationToken)
            {
                CourseSection course_section = await _unitOfWork.CourseSectionRepository.GetByIdAsync(request.SectionId) ?? throw new Exception();

                _unitOfWork.Mapper.Map(request.Model, course_section);

                course_section.Id = request.SectionId;

                _unitOfWork.CourseSectionRepository.Update(course_section);

                await _unitOfWork.SaveChangesAsync();

                if (request.Model.Lessons != null && request.Model.Lessons.Count != 0)
                {
                    await mediator.Send(new UpsertLessonsCommand()
                    {
                        Models = request.Model.Lessons
                    }, cancellationToken);
                }

                return course_section;

            }
        }
    }
}
