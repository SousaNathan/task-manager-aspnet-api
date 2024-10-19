using System.Net;
using TaskManager.Exception.Resource;

namespace TaskManager.Exception.ExceptionBase;

public class InvalidLoginException : TaskManagerException
{
    public InvalidLoginException() : base(ResourceErrorMessages.EMAIL_OR_PASSWORD_INVALID)
    {

    }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
