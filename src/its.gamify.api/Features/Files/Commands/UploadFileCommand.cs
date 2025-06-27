using its.gamify.core;
using its.gamify.core.IntegrationServices.Interfaces;
using its.gamify.core.Models.Files;
using MediatR;

namespace its.gamify.api.Features.Files.Commands
{
    public class UploadFileCommand : FileCreateModel, IRequest<FileResponseModel>
    {
        class CommandHandler : IRequestHandler<UploadFileCommand, FileResponseModel>
        {
            private readonly IFirebaseService firebaseService;
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IFirebaseService firebaseService,
                IUnitOfWork unitOfwork)
            {
                this.unitOfWork = unitOfwork;
                this.firebaseService = firebaseService;
            }
            public async Task<FileResponseModel> Handle(UploadFileCommand request, CancellationToken cancellationToken)
            {
                var res = await firebaseService.UploadFileAsync(request.File, "its-gamify/storage");
                if (!string.IsNullOrEmpty(res.url))
                {
                    await unitOfWork.FileRepository.AddAsync(new domains.Entities.FileEntity()
                    {
                        Id = Guid.NewGuid(),
                        FileName = res.fileName,
                        Url = res.url
                    });
                }
                throw new InvalidOperationException("Upload File Failed");
            }
        }

    }
}
