using APICOFFE.CustomExceptionHandler.Abstracts;
using APICOFFE.DTOs;
using APICOFFE.Exceptions;
using System.Net;
using System.Net.Mime;

namespace APICOFFE.CustomExceptionHandler.Concretes;

public class ExistExceptionHandler : IExceptionHandler
{
    public ExceptionResultDto Handle(Exception exception)
    {
        var notFoundException = (ExistException)exception;

        return new ExceptionResultDto(MediaTypeNames.Text.Plain, (int)HttpStatusCode.NotAcceptable, notFoundException.Message);
    }
}
