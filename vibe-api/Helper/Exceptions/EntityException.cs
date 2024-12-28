using System.Net;

namespace vibe_api.Helper.Exceptions;

public class EntityException(EntityErrorMessage message)
    : ApplicationException(HttpStatusCode.BadRequest, message.ToString());

public enum EntityErrorMessage
{
    EntityNotFound,
}