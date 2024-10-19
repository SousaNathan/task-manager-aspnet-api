﻿using System.Net;

namespace TaskManager.Exception.ExceptionBase;

public class NotFoundException : TaskManagerException
{
    public NotFoundException(string message) : base(message) { }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}