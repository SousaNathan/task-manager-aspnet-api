namespace TaskManager.Domain.Repositories.Task;

public interface ITaskReadOnlyRepository
{
    Task<List<Entities.Task>> GetAll(Entities.User user);

    Task<Entities.Task?> GetById(Entities.User user, long id);
}
