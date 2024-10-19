using TaskManager.Communication.Requests;

namespace TaskManager.Application.UseCases.Users.Update;

public interface IUpdateUserUseCase
{
    Task Execute(RequestUpdateUserJson request);
}
