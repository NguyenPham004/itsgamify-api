using its.gamify.core;
using its.gamify.core.IntegrationServices.Interfaces;
using its.gamify.core.Models.Files;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Files.Commands
{
    public class UploadFileCommand : FileCreateModel, IRequest<FileEntity>
    {
        class CommandHandler : IRequestHandler<UploadFileCommand, FileEntity>
        {
            private readonly IFirebaseService firebaseService;
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IFirebaseService firebaseService,
                IUnitOfWork unitOfwork)
            {
                this.unitOfWork = unitOfwork;
                this.firebaseService = firebaseService;
            }
            public async Task<FileEntity> Handle(UploadFileCommand request, CancellationToken cancellationToken)
            {
                var res = await firebaseService.UploadFileAsync(request.File, "its-gamify/storage");
                var fileSize = request.File.Length;
                if (!string.IsNullOrEmpty(res.url))
                {
                    var file = new domains.Entities.FileEntity()
                    {
                        Id = Guid.NewGuid(),
                        FileName = res.fileName,
                        Url = res.url,
                        ContentType = request.File.ContentType,
                        Extension = Path.GetExtension(res.fileName).Replace(".", ""),
                        Size = fileSize,
                    };
                    await unitOfWork.FileRepository.AddAsync(file);
                    await unitOfWork.SaveChangesAsync();
                    return file;
                }
                else
                    throw new InvalidOperationException("Upload File Failed");
            }
        }

    }
}
