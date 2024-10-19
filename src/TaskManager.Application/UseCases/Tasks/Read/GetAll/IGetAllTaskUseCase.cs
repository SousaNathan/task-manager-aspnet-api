using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks.Read.GetAll;

public interface IGetAllTaskUseCase
{
    Task<ResponseGetTasksJson> Execute();
}