namespace TaskManager.Exception.ExceptionBase;

public abstract class TaskManagerException : SystemException
{
    protected TaskManagerException(string message) : base(message) { }

    public abstract int StatusCode { get; }

    public abstract List<string> GetErrors();
}
