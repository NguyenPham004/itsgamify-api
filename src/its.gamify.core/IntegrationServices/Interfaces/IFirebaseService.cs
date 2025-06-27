using Microsoft.AspNetCore.Http;

namespace its.gamify.core.IntegrationServices.Interfaces;

public interface IFirebaseService
{
    Task<(string fileName, string url)> UploadFileAsync(IFormFile file, string directory);

}
