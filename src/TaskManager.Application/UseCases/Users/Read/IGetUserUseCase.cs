using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Users.Read;

public interface IGetUserUseCase
{
    Task<ResponseUserProfileJson> Execute();
}
