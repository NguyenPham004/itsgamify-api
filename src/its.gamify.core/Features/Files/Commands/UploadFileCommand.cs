using its.gamify.core;
using its.gamify.core.IntegrationServices.Interfaces;
using its.gamify.core.Models.Files;
using its.gamify.core.Services;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.Files.Commands
{
    public class UploadFileCommand : FileCreateModel, IRequest<FileEntity>
    {
        class CommandHandler(
            IS3Service _s3Service,
            IUnitOfWork _unitOfWork
        ) : IRequestHandler<UploadFileCommand, FileEntity>
        {

            public async Task<FileEntity> Handle(UploadFileCommand request, CancellationToken cancellationToken)
            {
                var (fileName, url) = await _s3Service.UploadFileAsync(request.File);
                var fileSize = request.File.Length;
                if (!string.IsNullOrEmpty(url))
                {
                    var file = new domains.Entities.FileEntity()
                    {
                        Id = Guid.NewGuid(),
                        FileName = fileName,
                        Url = url,
                        ContentType = request.File.ContentType,
                        Extension = Path.GetExtension(fileName).Replace(".", ""),
                        Size = fileSize,
                    };
                    // Check Duplicate Link 
                    var fileExists = await _unitOfWork.FileRepository.WhereAsync(x => x.FileName == fileName);
                    foreach (var fileInDb in fileExists)
                    {
                        fileInDb.Url = url;
                        _unitOfWork.FileRepository.Update(fileInDb);
                    }

                    await _unitOfWork.FileRepository.AddAsync(file, cancellationToken);
                    await _unitOfWork.SaveChangesAsync();

                    return file;
                }
                else
                    throw new InvalidOperationException("Upload File Failed");
            }
        }

    }
}
