using vibe_api.Entity.Token;

namespace vibe_api.Entity;

public interface IVideo : IEntity
{
    public UploadToken UploadToken { get; set; }
}