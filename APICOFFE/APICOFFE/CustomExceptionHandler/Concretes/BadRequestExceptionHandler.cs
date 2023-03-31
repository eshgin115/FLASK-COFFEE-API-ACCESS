using APICOFFE.CustomExceptionHandler.Abstracts;
using APICOFFE.DTOs;
using APICOFFE.Exceptions;
using System.Net;
using System.Net.Mime;

namespace APICOFFE.CustomExceptionHandler.Concretes;

public class BadRequestExceptionHandler : IExceptionHandler
{
    public ExceptionResultDto Handle(ApplicationException exception)
    {
        var badRequestException = (BadRequestException)exception;

        return new ExceptionResultDto(MediaTypeNames.Text.Plain, (int)HttpStatusCode.BadRequest, badRequestException.Message);
    }
}
