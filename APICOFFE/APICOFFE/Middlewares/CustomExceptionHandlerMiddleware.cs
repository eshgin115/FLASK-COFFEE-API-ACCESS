using APICOFFE.CustomExceptionHandler.Concretes;
using APICOFFE.Exceptions;
using System.Net;
using System.Net.Mime;
using System.Security.Claims;
using System.Text.Json;

namespace APICOFFE.Middlewares;

//public class CustomExceptionHandlerMiddleware
//{
//    private readonly ILogger _logger;
//    private readonly RequestDelegate _next;
//    private readonly IWebHostEnvironment _hostingEnvironment;
//    private readonly ExceptionHandlerService _exceptionHandlerService = new ExceptionHandlerService();

//    public CustomExceptionHandlerMiddleware(
//        RequestDelegate next,
//        ILoggerFactory loggerFactory,
//        IWebHostEnvironment hostingEnvironment)
//    {
//        _next = next;
//        _logger = loggerFactory.CreateLogger<CustomExceptionHandlerMiddleware>();
//        _hostingEnvironment = hostingEnvironment;
//        RegisterCustomExceptionHandlers();
//    }



//    public async Task Invoke(HttpContext context)
//    {
//        try
//        {
//            await _next(context);
//        }
//        catch (ApplicationException ex)
//        {
//            await HandleCustomExceptionsAsync(context, ex);
//        }
//        catch (Exception ex)
//        {
//            await LogFailedRequestAsync(context, ex);
//        }
//    }

//    private void RegisterCustomExceptionHandlers()
//    {
//        _exceptionHandlerService.RegisterHandler<ValidationException>(() => new ValidationExceptionHandler());
//        _exceptionHandlerService.RegisterHandler<ExistException>(() => new ExistExceptionHandler());
//        _exceptionHandlerService.RegisterHandler<BadRequestException>(() => new BadRequestExceptionHandler());
//        _exceptionHandlerService.RegisterHandler<NotFoundException>(() => new NotFoundExceptionHandler());
//        _exceptionHandlerService.RegisterHandler<ForbiddenException>(() => new ForbiddenExceptionHandler());
//        _exceptionHandlerService.RegisterHandler<UnauthorizedException>(() => new UnauthorizedExceptionHandler());
//    }

//    private Task HandleCustomExceptionsAsync(HttpContext context, ApplicationException exception)
//    {
//        var exceptionResult = _exceptionHandlerService.Handle(exception);

//        context.Response.ContentType = exceptionResult.ContentType;
//        context.Response.StatusCode = exceptionResult.HttpStatusCode;

//        return context.Response.WriteAsync(exceptionResult.Message);
//    }
//    private async Task LogFailedRequestAsync(HttpContext context, Exception exception)
//    {
//        var httpStatusCode = HttpStatusCode.InternalServerError;
//        var responseMessage = string.Empty;

//        if (_hostingEnvironment.IsProduction())
//        {
//            _logger.LogCritical(exception, "Internal server error happened.");
//            context.Response.ContentType = MediaTypeNames.Application.Json;
//            responseMessage = JsonSerializer.Serialize("Internal server error happened.");
//        }
//        else
//        {
//            _logger.LogCritical(responseMessage);
//            context.Response.ContentType = MediaTypeNames.Text.Plain;
//            responseMessage = GetFailedRequestMessage(context, exception);
//        }

//        context.Response.StatusCode = (int)httpStatusCode;
//        await context.Response.WriteAsync(responseMessage);
//    }

//    private string GetFailedRequestMessage(HttpContext context, Exception exception)
//    {
//        return "Failed Request\n" +
//            $"\tSchema: {context.Request?.Scheme}\n" +
//            $"\tHost: {context.Request?.Host}\n" +
//            $"\tUser: {context.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "anonymous"}\n" +
//            $"\tMethod: {context.Request?.Method}\n" +
//            $"\tPath: {context.Request?.Path}\n" +
//            $"\tQueryString: {context.Request?.QueryString}\n" +
//            $"\tErrorMessage: {exception.Message}\n" +
//            $"\tStacktrace (5):\n{exception.StackTrace?.Split('\n').Take(5).Aggregate((a, b) => a + "\n" + b)}";
//    }
//}

//public static class CustomExceptionHandlerMiddlewareExtensions
//{
//    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
//    {
//        return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
//    }
//}
public class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ExceptionHandlerCoordinator coordinator)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionsAsync(context, ex, coordinator);
        }
    }

    private Task HandleExceptionsAsync(HttpContext context, Exception exception, ExceptionHandlerCoordinator coordinator)
    {
        var exceptionResult = coordinator.Handle(exception);

        context.Response.ContentType = exceptionResult.ContentType;
        context.Response.StatusCode = exceptionResult.HttpStatusCode;

        return context.Response.WriteAsync(exceptionResult.Message);
    }
}

public static class CustomExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}