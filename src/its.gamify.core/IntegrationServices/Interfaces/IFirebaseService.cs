using Microsoft.AspNetCore.Http;

namespace its.gamify.core.IntegrationServices.Interfaces;

public interface IFirebaseService
{
    Task<(string url, string fileName)> UploadFileAsync(IFormFile file, string directory);

}
