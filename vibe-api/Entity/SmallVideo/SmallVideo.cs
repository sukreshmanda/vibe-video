using vibe_api.Entity.Token;

namespace vibe_api.Entity.SmallVideo;

public class SmallVideo : IVideo
{
    public long Id { get; set; }
    public required UploadToken UploadToken { get; set; }
}