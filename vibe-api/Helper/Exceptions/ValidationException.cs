using System.Net;

namespace vibe_api.Helper.Exceptions;

public class ValidationException(ValidationErrorMessage message)
    : ApplicationException(HttpStatusCode.BadRequest, message.ToString());

public enum ValidationErrorMessage
{
    VideoIsRequired,
    VideoFileIsTooLarge,
    FileIsNotAVideoFormat,
    InvalidUploadToken
}