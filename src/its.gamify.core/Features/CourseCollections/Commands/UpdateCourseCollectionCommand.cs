using FluentValidation;
using its.gamify.core;
using its.gamify.core.Models.CourseCollections;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.CourseCollections.Commands
{
    public class UpdateCourseCollectionCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public CourseCollectionUpdateModel Model { get; set; } = new();
        class CommandValidate : AbstractValidator<UpdateCourseCollectionCommand>
        {
            public CommandValidate()
            {
                RuleFor(x => x.Model.CourseId).NotEmpty().NotNull().WithMessage("Course Id can not null.");
            }
        }
        class CommandHandler : IRequestHandler<UpdateCourseCollectionCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IClaimsService claimsService;
            public CommandHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
            {
                this.unitOfWork = unitOfWork;
                this.claimsService = claimsService;
            }
            public async Task<bool> Handle(UpdateCourseCollectionCommand request, CancellationToken cancellationToken)
            {
                await unitOfWork.CourseRepository.EnsureExistsIfIdNotEmpty(request.Model.CourseId);
                var courseCollection = await unitOfWork.CourseCollectionRepository.GetByIdAsync(request.Id);
                if (courseCollection is not null)
                {
                    if (request.Model.CourseId != courseCollection.CourseId)
                    {
                        unitOfWork.Mapper.Map(request.Model, courseCollection);
                        unitOfWork.CourseCollectionRepository.Update(courseCollection);
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
                        }
                        await unitOfWork.SaveChangesAsync();
                        return await unitOfWork.SaveChangesAsync();
                    }
                    return false;
                }
                else throw new InvalidOperationException("Course collection not found");

            }
        }
    }
}
