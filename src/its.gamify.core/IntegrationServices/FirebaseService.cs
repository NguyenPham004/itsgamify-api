using Firebase.Auth;
using Firebase.Storage;
using its.gamify.core.IntegrationServices.Interfaces;
using its.gamify.domains.Models;
using Microsoft.AspNetCore.Http;

namespace its.gamify.core.IntegrationServices;

public class FirebaseService : IFirebaseService
{
    private FirebaseAuthProvider authProvider;
    private FirebaseAuthLink ServiceAccount { get; set; }
    private FirebaseStorage FirebaseStorage;
    public FirebaseService(AppSetting appSetting)
    {
        authProvider = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig(apiKey: appSetting.FirebaseConfig.ApiKey));
        ServiceAccount = authProvider.SignInWithEmailAndPasswordAsync(appSetting.FirebaseConfig.ServiceAccountAdmin, appSetting.FirebaseConfig.ServiceAccountPass).Result;
        FirebaseStorage = new FirebaseStorage(
                appSetting.FirebaseConfig.Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(ServiceAccount.FirebaseToken),
                    ThrowOnCancel = true

                });
    }
    public async Task<(string url, string fileName)> UploadFileAsync(IFormFile file, string directory)
    {
        if (file.Length > 0)
        {
            var fs = file.OpenReadStream();
            var auth = authProvider;

            var a = ServiceAccount;
            Console.Write(a.FirebaseToken);

            var cancellation = FirebaseStorage.Child("assets/" + directory).Child(file.FileName)
                .PutAsync(fs, CancellationToken.None);
            try
            {
                var result = await cancellation;
                return (file.FileName, result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        else throw new Exception("File is not existed!");
    }
}
