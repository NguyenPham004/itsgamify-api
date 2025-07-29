
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using its.gamify.domains.Models;
using Microsoft.AspNetCore.Http;

namespace its.gamify.core.Services;

public class PartETagModel
{
    public int PartNumber { get; set; }
    public string ETag { get; set; } = string.Empty;
}


public class InitiateMultipartUploadModel
{
    public string FileName { get; set; } = string.Empty;
}
public class GeneratePresignedUrlModel : InitiateMultipartUploadModel
{
    public string UploadId { get; set; } = string.Empty;
    public int PartNumber { get; set; }
}

public class CompleteMultipartUploadModel
{
    public string FileName { get; set; } = string.Empty;
    public string UploadId { get; set; } = string.Empty;
    public List<PartETagModel> PartETags { get; set; } = [];
}




public interface IS3Service
{
    Task<(string fileName, string url)> UploadFileAsync(IFormFile file);
    Task<Stream> GetFileAsync(string fileName);
    Task<string> GetPresignedUrlAsync(string fileName, TimeSpan expiry);
    Task<bool> FileExistsAsync(string fileName);

    //Upload multipart
    Task<string> InitiateMultipartUploadAsync(InitiateMultipartUploadModel model);

    Task<string> GeneratePresignedUrlForPartAsync(GeneratePresignedUrlModel model);

    Task<string> CompleteMultipartUploadAsync(CompleteMultipartUploadModel model);
    Task SetCorsConfigurationAsync();
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


    public async Task SetCorsConfigurationAsync()
    {
        using var client = CreateS3Client();

        var corsConfiguration = new CORSConfiguration
        {
            Rules =
                [
                    new CORSRule
                    {
                        AllowedHeaders = ["*"],
                        AllowedMethods = ["PUT", "POST", "GET"],
                        AllowedOrigins = ["*"],  // Thay bằng domains cụ thể
                        ExposeHeaders = ["ETag"],
                        MaxAgeSeconds = 3000
                    }
                ]
        };

        var putRequest = new PutCORSConfigurationRequest
        {
            BucketName = _appSetting.AWSConfig.S3BucketName,
            Configuration = corsConfiguration
        };

        await client.PutCORSConfigurationAsync(putRequest);
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

        var url = $"{_appSetting.AWSConfig.S3BaseObjectUrl}?fileName={objName}&expiryMinutes=60";

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

    public async Task<string> InitiateMultipartUploadAsync(InitiateMultipartUploadModel model)
    {
        using var client = CreateS3Client();

        var initiateRequest = new InitiateMultipartUploadRequest
        {
            BucketName = _appSetting.AWSConfig.S3BucketName,
            Key = model.FileName
        };

        var initiateResponse = await client.InitiateMultipartUploadAsync(initiateRequest);
        return initiateResponse.UploadId;
    }

    public async Task<string> GeneratePresignedUrlForPartAsync(GeneratePresignedUrlModel model)
    {
        using var client = CreateS3Client();

        var presignRequest = new GetPreSignedUrlRequest
        {
            BucketName = _appSetting.AWSConfig.S3BucketName,
            Key = model.FileName,
            UploadId = model.UploadId,
            PartNumber = model.PartNumber,
            Verb = HttpVerb.PUT,
            Expires = DateTime.UtcNow.Add(TimeSpan.FromMinutes(15))
        };

        return await client.GetPreSignedURLAsync(presignRequest);
    }

    public async Task<string> CompleteMultipartUploadAsync(CompleteMultipartUploadModel model)
    {
        using var client = CreateS3Client();

        var partETags = model.PartETags.Select(dto => new PartETag
        {
            PartNumber = dto.PartNumber,
            ETag = dto.ETag
        }).ToList();


        var completeRequest = new CompleteMultipartUploadRequest
        {
            BucketName = _appSetting.AWSConfig.S3BucketName,
            Key = model.FileName,
            UploadId = model.UploadId,
            PartETags = partETags
        };

        await client.CompleteMultipartUploadAsync(completeRequest);

        return $"{_appSetting.AWSConfig.S3BaseObjectUrl}?fileName={model.FileName}&expiryMinutes=60";
    }
}