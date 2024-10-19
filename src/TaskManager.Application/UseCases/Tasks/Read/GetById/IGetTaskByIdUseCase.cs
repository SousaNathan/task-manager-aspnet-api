using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks.Read.GetById;

public interface IGetTaskByIdUseCase
{
    Task<ResponseGetTaskJson> Execute(long id);
}
