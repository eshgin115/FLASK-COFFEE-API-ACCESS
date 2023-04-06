using APICOFFE.CustomExceptionHandler.Abstracts;
using APICOFFE.DTOs;
using APICOFFE.Exceptions;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace APICOFFE.CustomExceptionHandler.Concretes;
public class UnauthorizedExceptionHandler : IExceptionHandler
{
    public ExceptionResultDto Handle(Exception exception)
    {
        var unauthorizedException = (UnauthorizedException)exception;

        return new ExceptionResultDto(MediaTypeNames.Application.Json, (int)HttpStatusCode.Unauthorized, JsonSerializer.Serialize(unauthorizedException.Message));
    }
}