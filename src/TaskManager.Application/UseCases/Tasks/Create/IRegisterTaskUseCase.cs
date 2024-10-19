using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks.Create;

public interface IRegisterTaskUseCase
{
    Task<ResponseRegisterTaskJson> Execute(RequestRegisterTaskJson request);
}
