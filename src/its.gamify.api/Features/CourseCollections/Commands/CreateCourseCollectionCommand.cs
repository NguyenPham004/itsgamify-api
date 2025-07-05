using FluentValidation;
using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using its.gamify.core.Models.CourseCollections;
using its.gamify.core.Models.Questions;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.CourseCollections.Commands
{
    public class CreateCourseCollectionCommand : CourseCollectionCreateModel, IRequest<CourseCollection>
    {
        class CommandHandler : IRequestHandler<CreateCourseCollectionCommand, CourseCollection>
        {
            private readonly IClaimsService claimsService;
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
            {
                this.unitOfWork = unitOfWork;
                this.claimsService = claimsService;
            }
            public async Task<CourseCollection> Handle(CreateCourseCollectionCommand request, CancellationToken cancellationToken)
            {
                if (claimsService.CurrentUser == Guid.Empty) throw new Exception("Check user session login");
                var courseCollection = unitOfWork.Mapper.Map<CourseCollection>(request);
                courseCollection.UserId = claimsService != null ? claimsService.CurrentUser : Guid.Empty;
                //await unitOfWork.UserRepository.EnsureExistsIfIdNotEmpty(courseCollection.UserId);
                await unitOfWork.CourseRepository.EnsureExistsIfIdNotEmpty(request.CourseId);
                var find = await unitOfWork.CourseCollectionRepository.FirstOrDefaultAsync(x => x.UserId == claimsService.CurrentUser && x.CourseId == request.CourseId);
                if (find is not null) throw new Exception("This course is saved.");
                await unitOfWork.CourseCollectionRepository.AddAsync(courseCollection);
                await unitOfWork.SaveChangesAsync();
                var courseMetric = await unitOfWork.CourseMetricRepository.GetByIdAsync(courseCollection.CourseId);
                if (courseMetric != null)
                {
                    ++courseMetric.SaveCount;
                    unitOfWork.CourseMetricRepository.Update(courseMetric);
                }
                else
                {
                    CourseMetric cm = new CourseMetric()
                    {
                        CourseId = courseCollection.CourseId,
                        SaveCount = 1,
                    };
                    await unitOfWork.CourseMetricRepository.AddAsync(cm);
                }

                await unitOfWork.SaveChangesAsync();
                return courseCollection;
            }
        }
        /*class CommandValidation : AbstractValidator<CreateCourseCollectionCommand>
        {
            public CommandValidation()
            {
                RuleFor(x => x.CourseId).NotEmpty().NotNull().WithMessage("Course not found.");

            }
            
        }*/
    }
}
