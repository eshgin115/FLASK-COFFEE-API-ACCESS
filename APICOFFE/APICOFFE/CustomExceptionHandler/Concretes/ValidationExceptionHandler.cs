﻿using APICOFFE.CustomExceptionHandler.Abstracts;
using APICOFFE.DTOs;
using APICOFFE.Exceptions;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace APICOFFE.CustomExceptionHandler.Concretes;

public class ValidationExceptionHandler : IExceptionHandler
{
    public ExceptionResultDto Handle(ApplicationException exception)
    {
        var validationException = (ValidationException)exception;

        return new ExceptionResultDto(MediaTypeNames.Application.Json, (int)HttpStatusCode.BadRequest, JsonSerializer.Serialize(validationException.Errors));
    }
}