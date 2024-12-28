using vibe_api.Entity.SmallVideo;
using vibe_api.Entity.Token;
using vibe_api.Repository;
using vibe_api.Service.BlobService;
using vibe_api.Validator;

namespace vibe_api.Service;

public class SmallVideoUploadService(
    IRepository<UploadToken> uploadTokenRepository,
    IValidator<IFormFile> formFileValidator,
    IBlobService<SmallVideo> smallVideoBlobService,
    UploadTokenService uploadTokenService)
{
    private IRepository<UploadToken> UploadTokenRepository { get; } = uploadTokenRepository;
    private IValidator<IFormFile> FormFileValidator { get; } = formFileValidator;
    private IBlobService<SmallVideo> SmallVideoBlobService { get; } = smallVideoBlobService;
    private UploadTokenService UploadTokenService { get; } = uploadTokenService;


    public string GetUploadToken()
    {
        //TODO: 1. Validate User Permission

        //2. Generate a new Upload Token for User
        var randomString = Guid.NewGuid().ToString();

        //3. Save the Token in DB
        var uploadToken = UploadTokenRepository.Add(new UploadToken()
        {
            TokenId = randomString,
        });

        //4. Return the token to User
        return uploadToken.TokenId;
    }

    public async Task Upload(IFormFile video, string token)
    {
        //1. Validate Video File
        FormFileValidator.Validate(video);

        //2. Validate token 
        var uploadToken = UploadTokenService.VerifyToken(token);

        //3. Upload File to Blob based on token
        await SmallVideoBlobService.UploadVideo(video, new SmallVideo
        {
            UploadToken = uploadToken,
        });
    }
}