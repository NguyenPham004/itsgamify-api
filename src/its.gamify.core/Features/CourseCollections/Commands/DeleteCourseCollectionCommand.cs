using MediatR;

namespace its.gamify.core.Features.CourseCollections.Commands
{
    public class DeleteCourseCollectionCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCourseCollectionCommand, bool>
        {

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
