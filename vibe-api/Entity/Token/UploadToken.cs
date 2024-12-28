namespace vibe_api.Entity.Token;

public class UploadToken : IToken, IEntity
{
    public required string TokenId { get; init; }
    public long Id { get; set; }
}