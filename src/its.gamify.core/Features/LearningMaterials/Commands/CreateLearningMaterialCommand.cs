using its.gamify.core.Features.Files.Commands;
using its.gamify.core;
using its.gamify.core.Models.LearningMaterials;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.LearningMaterials.Commands
{
    public class CreateLearningMaterialCommand : IRequest<LearningMaterial>
    {
        public required LearningMaterialCreateModel Model { get; set; }

        class CommandHandler : IRequestHandler<CreateLearningMaterialCommand, LearningMaterial>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMediator _mediator;

            public CommandHandler(IUnitOfWork unitOfWork,
                IMediator mediator)
            {
                this._mediator = mediator;
                this._unitOfWork = unitOfWork;
            }
            public async Task<LearningMaterial> Handle(CreateLearningMaterialCommand request, CancellationToken cancellationToken)
            {


                var file = await _mediator.Send(new UploadFileCommand()
                {
                    File = request.Model.File,
                }, cancellationToken);

                var material = new LearningMaterial
                {
                    Name = file.FileName,
                    Size = file.Size.ToString(),
                    Type = file.Extension,
                    Url = file.Url,
                    FileId = file.Id,
                    CourseId = request.Model.CourseId
                };

                await _unitOfWork.LearningMaterialRepository.AddAsync(material, cancellationToken);
                await _unitOfWork.SaveChangesAsync();
                return material;
            }
        }
    }
}
