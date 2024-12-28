using Azure.Storage.Blobs;
using vibe_api.Entity;

namespace vibe_api.Service.BlobService;

public class VideoBlobService<T>(BlobServiceClient blobServiceClient) : IBlobService<T> where T : class, IVideo
{
    private BlobServiceClient BlobServiceClient { get; } = blobServiceClient;

    public async Task UploadVideo(IFormFile file, T video)
    {
        var fileFormat = Path.GetExtension(file.FileName)?.ToLowerInvariant();
        var blobContainerClient = BlobServiceClient.GetBlobContainerClient("small-video");
        var blobClient = blobContainerClient.GetBlobClient($"{video.UploadToken.TokenId}{fileFormat}");
        await blobClient.UploadAsync(file.OpenReadStream());
    }
}