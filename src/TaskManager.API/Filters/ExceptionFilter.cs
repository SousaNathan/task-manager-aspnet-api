using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Exception.ExceptionBase;
using TaskManager.Communication.Responses;
using TaskManager.Exception.Resource;

namespace TaskManager.API.Filters;

public class ExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is TaskManagerException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private static void HandleProjectException(ExceptionContext context)
    {
        var cashFlowException = (TaskManagerException)context.Exception;
        var errorResponse = new ResponseErrorJson(cashFlowException.GetErrors());

        context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private static void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOW_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
