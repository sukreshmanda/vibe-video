using vibe_api.Entity;

namespace vibe_api.Service.BlobService;

public interface IBlobService<in T> where T: class, IVideo
{
    Task UploadVideo(IFormFile file, T video);
}