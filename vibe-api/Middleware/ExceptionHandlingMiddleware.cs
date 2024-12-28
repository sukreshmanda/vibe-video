using System.Net;
using Newtonsoft.Json;
using vibe_api.Helper.Exceptions;

namespace vibe_api.Middleware;

public class ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) : IMiddleware
{
    private ILogger<ExceptionHandlingMiddleware> Logger { get; } = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            Logger.LogError(e, e.Message);
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exception switch
        {
            ValidationException validationException => (int)validationException.StatusCode,
            EntityException => (int)HttpStatusCode.InternalServerError,
            _ => StatusCodes.Status500InternalServerError
        };

        var response = new
        {
            message = exception.Message, context.Response.StatusCode
        };
        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
}