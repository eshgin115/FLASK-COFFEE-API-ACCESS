﻿
using APICOFFE.DTOs;

namespace APICOFFE.CustomExceptionHandler.Abstracts;

public interface IExceptionHandler
{
    public ExceptionResultDto Handle(Exception exception);
}
