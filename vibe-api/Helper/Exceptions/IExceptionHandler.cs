namespace vibe_api.Helper.Exceptions;

public interface IExceptionHandler<in T> where T : System.Exception
{
    void Handle(T exception);
}