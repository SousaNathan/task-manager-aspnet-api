namespace TaskManager.Domain.Repositories.User;

public interface IUserWriteOnlyRepository
{
    System.Threading.Tasks.Task Add(Entities.User user);

    System.Threading.Tasks.Task Delete(Entities.User user);
}
