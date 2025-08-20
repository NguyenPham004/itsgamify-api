using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.CourseCollections.Commands
{
    public class UpsertCourseCollectionCommand : IRequest<CourseCollection>
    {
        public Guid CourseId { get; set; }

        class CommandHandler(IUnitOfWork unitOfWork, IClaimsService claimsService, IMediator mediator) : IRequestHandler<UpsertCourseCollectionCommand, CourseCollection>
        {
            public async Task<CourseCollection> Handle(UpsertCourseCollectionCommand request, CancellationToken cancellationToken)
            {

                var courseCollection = await unitOfWork
                    .CourseCollectionRepository
                    .FirstOrDefaultAsync(x =>
                        x.CourseId == request.CourseId &&
                        x.UserId == claimsService.CurrentUser,
                        withDeleted: true,
                        cancellationToken: cancellationToken);
                if (courseCollection == null)
                {
                    return await mediator.Send(new CreateCourseCollectionCommand
                    {
                        CourseId = request.CourseId
                    }, cancellationToken);
                }

                var courseMetric = await unitOfWork.CourseMetricRepository.FirstOrDefaultAsync(x => x.CourseId == courseCollection.CourseId)
                     ?? throw new Exception("Course metric not found");

                if (courseCollection.IsDeleted)
                {
                    courseCollection.IsDeleted = false;
                    ++courseMetric.SaveCount;
                    unitOfWork.CourseCollectionRepository.Update(courseCollection);
                }
                else
                {
                    --courseMetric.SaveCount;
                    unitOfWork.CourseCollectionRepository.SoftRemove(courseCollection);
                }

                unitOfWork.CourseMetricRepository.Update(courseMetric);
                await unitOfWork.SaveChangesAsync();
                return courseCollection;
            }

        }
    }
}

