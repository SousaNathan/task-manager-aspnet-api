namespace TaskManager.Domain.Repositories.Task;

public interface ITaskWriteOnlyRepository
{
    System.Threading.Tasks.Task Add(Entities.Task expense);

    System.Threading.Tasks.Task Delete(long id);
}
