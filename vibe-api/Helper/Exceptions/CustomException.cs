using System.Net;

namespace vibe_api.Helper.Exceptions;

public abstract class ApplicationException(HttpStatusCode statusCode, string errorMessage) : Exception(errorMessage)
{
    public HttpStatusCode StatusCode { get; set; } = statusCode;
    public string ErrorMessage { get; set; } = errorMessage;
}