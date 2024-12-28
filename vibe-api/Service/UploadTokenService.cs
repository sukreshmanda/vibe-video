using vibe_api.Entity.Token;
using vibe_api.Helper.Exceptions;
using vibe_api.Repository;

namespace vibe_api.Service;

public class UploadTokenService(IRepository<UploadToken> repository)
{
    private IRepository<UploadToken> Repository { get; } = repository;

    public UploadToken VerifyToken(string token)
    {
        var uploadTokens = Repository.Entities
            .Where(a => a.TokenId == token)
            .ToList();
        if (uploadTokens.Count != 1) throw new ValidationException(ValidationErrorMessage.InvalidUploadToken);
        return uploadTokens.First();
    }
}