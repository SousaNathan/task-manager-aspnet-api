using TaskManager.Communication.Requests;

namespace TaskManager.Application.UseCases.Users.ChangePassword;

public interface IChangePasswordUseCase
{
    Task Execute(RequestChangePasswordJson reques);
}
