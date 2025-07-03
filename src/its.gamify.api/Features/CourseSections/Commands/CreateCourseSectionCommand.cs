using its.gamify.core;
using its.gamify.core.IntegrationServices.Interfaces;
using its.gamify.core.Models.CourseSections;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.CourseSections.Commands
{
    public class CreateCourseSectionCommand : CourseSectionCreateModel, IRequest<CourseSection>
    {
        class CommandHandler : IRequestHandler<CreateCourseSectionCommand, CourseSection>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IFirebaseService firebaseSerivce;
            private readonly IMediator mediator;
            public CommandHandler(IUnitOfWork unitOfWork,
                IFirebaseService firebaseService,
                IMediator mediator)
            {
                this.mediator = mediator;
                this.firebaseSerivce = firebaseService;
                this.unitOfWork = unitOfWork;
            }
            public async Task<CourseSection> Handle(CreateCourseSectionCommand request, CancellationToken cancellationToken)
            {
                // bool isUpdate = request.CreateId != null;
                CourseSection? current = unitOfWork.Mapper.Map<CourseSection>(request);
                await unitOfWork.CourseSectionRepository.AddAsync(current);
                await unitOfWork.SaveChangesAsync();

                return current;

            }
        }
    }
}
