namespace TaskManager.Domain.Repositories.Task;

public interface ITaskUpdateOnlyRepository
{
    Task<Entities.Task?> GetById(Entities.User user, long id);

    void Update(Entities.Task expense);
}
