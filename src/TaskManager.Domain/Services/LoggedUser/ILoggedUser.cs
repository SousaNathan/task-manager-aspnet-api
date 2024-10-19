using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Services.LoggedUser;

public interface ILoggedUser
{
    Task<User> Get();
}
