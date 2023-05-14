using System.Net;
using System.Text.Json;

namespace RectanglesDemo.Api.CustomMiddlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Serilog.ILogger _logger;
    public ExceptionMiddleware(RequestDelegate next, Serilog.ILogger logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.Error($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex, HttpStatusCode.InternalServerError);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        var errorDetails = new ErrorDetails(exception.Message);
        await context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
    }
}

public class ErrorDetails
{
    public string Message { get; init; }
    public string? Description { get; }

    public ErrorDetails(string errorMessage)
    {
        Message = errorMessage;
    }

    public ErrorDetails(string errorMessage, string? errorDetail) : this(errorMessage)
    {
        Description = errorDetail;
    }
}