using vibe_api.helper;
using vibe_api.Helper.Exceptions;

namespace vibe_api.Validator;

public class SmallVideoFormFileValidator : IValidator<IFormFile>
{
    public void Validate(IFormFile entity)
    {
        if (entity == null) throw new ValidationException(ValidationErrorMessage.VideoIsRequired);
        if (entity.Length > SmallVideoConstants.VideoSize)
            throw new ValidationException(ValidationErrorMessage.VideoFileIsTooLarge);

        var fileFormat = Path.GetExtension(entity.FileName).ToLowerInvariant();
        if (fileFormat is null || !SmallVideoConstants.VideoExtensions.Contains(fileFormat))
            throw new ValidationException(ValidationErrorMessage.FileIsNotAVideoFormat);
    }
}