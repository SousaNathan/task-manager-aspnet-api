namespace TaskManager.Application.UseCases.Tasks.Delete;

public interface IDeleteTaskUseCase
{
    Task Execute(long id);
}
