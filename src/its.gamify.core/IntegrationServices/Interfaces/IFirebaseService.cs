namespace its.gamify.core.IntegrationServices.Interfaces;

public interface IFirebaseService
{
    Task<(string url, string fileName)> UploadFileAsync(string url, string fileName);

}
