using FluentValidation;
using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using its.gamify.core.Models.CourseCollections;
using its.gamify.core.Models.Questions;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.CourseCollections.Commands
{
    public class CreateCourseCollectionCommand : CourseCollectionCreateModel, IRequest<CourseCollection>
    {
        public CourseCollectionViewModel Model { get; set; } = new();
        class CommandValidation : AbstractValidator<CourseCollectionViewModel>
        {
            public CommandValidation()
            {
                RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage("Check session login user.");
                RuleFor(x => x.CourseId).NotEmpty().NotNull().WithMessage("Course not found.");

            }
            class CommandHandler : IRequestHandler<CreateCourseCollectionCommand, CourseCollection>
            {
                private readonly IUnitOfWork unitOfWork;
                public CommandHandler(IUnitOfWork unitOfWork)
                {
                    this.unitOfWork = unitOfWork;

                }
                public async Task<CourseCollection> Handle(CreateCourseCollectionCommand request, CancellationToken cancellationToken)
                {
                    var question = unitOfWork.Mapper.Map<CourseCollection>(request);
                    await unitOfWork.UserRepository.EnsureExistsIfIdNotEmpty(request.Model.UserId);
                    await unitOfWork.CourseCollectionRepository.EnsureExistsIfIdNotEmpty(request.Model.CourseId);
                    await unitOfWork.CourseCollectionRepository.AddAsync(question);
                    await unitOfWork.SaveChangesAsync();
                    return question;
                }
            }
        }
    }
}
