using TaskManager.Communication.Requests;

namespace TaskManager.Application.UseCases.Tasks.Update;

public interface IUpdateTaskUseCase
{
    Task Execute(long id, RequestRegisterTaskJson request);
}
