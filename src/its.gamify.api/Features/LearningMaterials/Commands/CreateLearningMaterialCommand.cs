using its.gamify.core;
using its.gamify.core.IntegrationServices.Interfaces;
using its.gamify.core.Models.LearningMaterials;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.LearningMaterials.Commands
{
    public class CreateLearningMaterialCommand : IRequest<LearningMaterial>
    {
        public LearningMaterialCreateModel Model { get; set; }
        public Guid CourseId { get; set; }
        class CommandHandler : IRequestHandler<CreateLearningMaterialCommand, LearningMaterial>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IFirebaseService firebaseService;
            public CommandHandler(IUnitOfWork unitOfWork,
                IFirebaseService firebaseService)
            {
                this.firebaseService = firebaseService;
                this.unitOfWork = unitOfWork;
            }
            public async Task<LearningMaterial> Handle(CreateLearningMaterialCommand request, CancellationToken cancellationToken)
            {
                var fileRes = await firebaseService.UploadFileAsync(request.Model.File.File, request.Model.File.Directory ?? string.Empty);
                var learningMate = new LearningMaterial()
                {
                    Title = request.Model.Title,
                    CourseId = request.CourseId,
                    Type = request.Model.Type,
                    Description = request.Model.Description,
                    Url = fileRes.url
                };
                await unitOfWork.LearningMaterialRepository.AddAsync(learningMate);
                await unitOfWork.SaveChangesAsync();
                return learningMate;
            }
        }
    }
}
