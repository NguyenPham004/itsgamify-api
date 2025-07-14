
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using its.gamify.domains.Models;
using Microsoft.AspNetCore.Http;

namespace its.gamify.core.Services;

public interface IS3Service
{
    Task<(string fileName, string url)> UploadFileAsync(IFormFile file);
    Task<Stream> GetFileAsync(string fileName);
    Task<string> GetPresignedUrlAsync(string fileName, TimeSpan expiry);
    Task<bool> FileExistsAsync(string fileName);
}

public class S3Service(AppSetting _appSetting) : IS3Service
{
    private AmazonS3Client CreateS3Client()
    {
        var config = new AmazonS3Config()
        {
            RegionEndpoint = Amazon.RegionEndpoint.APSoutheast1
        };

        var credentials = new BasicAWSCredentials(
            _appSetting.AWSConfig.S3AccessKey,
            _appSetting.AWSConfig.S3SecretKey
        );

        return new AmazonS3Client(credentials, config);
    }

    public async Task<(string fileName, string url)> UploadFileAsync(IFormFile file)
    {
        await using var memoryStr = new MemoryStream();

        await file.CopyToAsync(memoryStr);

        var fileExt = Path.GetExtension(file.Name);
        var objName = $"{Guid.NewGuid()}.{fileExt}";

        var config = new AmazonS3Config()
        {
            RegionEndpoint = Amazon.RegionEndpoint.APSoutheast1
        };

        var uploadRequest = new TransferUtilityUploadRequest()
        {
            InputStream = memoryStr,
            Key = objName,
            BucketName = _appSetting.AWSConfig.S3BucketName,
            CannedACL = S3CannedACL.NoACL
        };

        var credentials = new BasicAWSCredentials(
            _appSetting.AWSConfig.S3AccessKey,
            _appSetting.AWSConfig.S3SecretKey
        );

        using var client = new AmazonS3Client(credentials, config);

        var transferUtility = new TransferUtility(client);

        await transferUtility.UploadAsync(uploadRequest);

        var url = $"{_appSetting.AWSConfig.S3BaseObjectUrl}/{objName}";

        return (objName, url);
    }

    public async Task<Stream> GetFileAsync(string fileName)
    {
        using var client = CreateS3Client();

        var request = new GetObjectRequest()
        {
            BucketName = _appSetting.AWSConfig.S3BucketName,
            Key = fileName
        };

        var response = await client.GetObjectAsync(request);

        // Tạo MemoryStream để trả về
        var memoryStream = new MemoryStream();
        await response.ResponseStream.CopyToAsync(memoryStream);
        memoryStream.Position = 0;

        return memoryStream;
    }

    public async Task<string> GetPresignedUrlAsync(string fileName, TimeSpan expiry)
    {
        using var client = CreateS3Client();

        var request = new GetPreSignedUrlRequest()
        {
            BucketName = _appSetting.AWSConfig.S3BucketName,
            Key = fileName,
            Expires = DateTime.UtcNow.Add(expiry),
            Verb = HttpVerb.GET
        };

        return await client.GetPreSignedURLAsync(request);
    }

    public async Task<bool> FileExistsAsync(string fileName)
    {
        using var client = CreateS3Client();

        try
        {
            var request = new GetObjectMetadataRequest()
            {
                BucketName = _appSetting.AWSConfig.S3BucketName,
                Key = fileName
            };

            await client.GetObjectMetadataAsync(request);
            return true;
        }
        catch (AmazonS3Exception ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return false;
        }
    }
}