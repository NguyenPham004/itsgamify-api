using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using MediatR;

namespace its.gamify.api.Features.CourseCollections.Commands
{
    public class DeleteCourseCollectionCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        class CommandHandler : IRequestHandler<DeleteCourseCollectionCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteCourseCollectionCommand request, CancellationToken cancellationToken)
            {
                var courseCollection = await unitOfWork.CourseCollectionRepository.GetByIdAsync(request.Id);
                if (courseCollection is not null)
                {
                    unitOfWork.CourseCollectionRepository.SoftRemove(courseCollection);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Course collection not found");
            }
        }

    }
}
