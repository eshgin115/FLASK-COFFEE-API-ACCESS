using APICOFFE.CustomExceptionHandler.Abstracts;
using APICOFFE.DTOs;
using APICOFFE.Exceptions;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace APICOFFE.CustomExceptionHandler.Concretes;

public class ForbiddenExceptionHandler : IExceptionHandler
{
    public ExceptionResultDto Handle(Exception exception)
    {
        var forbiddenException = (ForbiddenException)exception;

        return new ExceptionResultDto(MediaTypeNames.Application.Json, (int)HttpStatusCode.Forbidden, JsonSerializer.Serialize(forbiddenException.Message));
    }
}