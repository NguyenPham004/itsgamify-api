using FluentValidation;
using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using its.gamify.core.Models.CourseCollections;
using its.gamify.core.Models.Questions;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.CourseCollections.Commands
{
    public class CreateCourseCollectionCommand : IRequest<CourseCollection>
    {
        public Guid CourseId { get; set; }
        class CommandHandler(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<CreateCourseCollectionCommand, CourseCollection>
        {

            public async Task<CourseCollection> Handle(CreateCourseCollectionCommand request, CancellationToken cancellationToken)
            {

                var courseCollection = await unitOfWork.CourseCollectionRepository.AddAsync(new CourseCollection
                {
                    CourseId = request.CourseId,
                    UserId = claimsService.CurrentUser
                }, cancellationToken);

                var courseMetric = await unitOfWork.CourseMetricRepository.FirstOrDefaultAsync(x => x.CourseId == courseCollection.CourseId);

                if (courseMetric != null)
                {
                    ++courseMetric.SaveCount;
                    unitOfWork.CourseMetricRepository.Update(courseMetric);
                }
                else
                {
                    CourseMetric cm = new()
                    {
                        CourseId = courseCollection.CourseId,
                        SaveCount = 1,
                    };
                    await unitOfWork.CourseMetricRepository.AddAsync(cm, cancellationToken);
                }

                await unitOfWork.SaveChangesAsync();

                return courseCollection;
            }
        }

    }
}
