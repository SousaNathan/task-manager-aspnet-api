using TaskManager.Domain.Repositories.User;
using TaskManager.Domain.Repositories;
using TaskManager.Domain.Services.LoggedUser;

namespace TaskManager.Application.UseCases.Users.Delete;

public class DeleteUserUseCase : IDeleteUserUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IUserWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserUseCase(
        ILoggedUser loggedUse,
        IUserWriteOnlyRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _loggedUser = loggedUse;
    }

    public async Task Execute()
    {
        var user = await _loggedUser.Get();

        await _repository.Delete(user);
        await _unitOfWork.Commit();
    }
}
