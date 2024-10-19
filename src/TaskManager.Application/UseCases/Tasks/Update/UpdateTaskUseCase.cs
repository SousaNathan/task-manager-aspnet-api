using AutoMapper;
using TaskManager.Application.UseCases.Tasks.Validator;
using TaskManager.Communication.Requests;
using TaskManager.Domain.Repositories;
using TaskManager.Domain.Repositories.Task;
using TaskManager.Domain.Services.LoggedUser;
using TaskManager.Exception.ExceptionBase;
using TaskManager.Exception.Resource;

namespace TaskManager.Application.UseCases.Tasks.Update;

public class UpdateTaskUseCase : IUpdateTaskUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITaskUpdateOnlyRepository _taskUpdateOnlyRepository;
    private readonly ILoggedUser _loggeUser;

    public UpdateTaskUseCase(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        ITaskUpdateOnlyRepository taskUpdateOnlyRepository,
        ILoggedUser loggedUser)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _taskUpdateOnlyRepository = taskUpdateOnlyRepository;
        _loggeUser = loggedUser;
    }

    public async Task Execute(long id, RequestRegisterTaskJson request)
    {
        Validate(request);

        var loggedUser = await _loggeUser.Get();
        var task = await _taskUpdateOnlyRepository.GetById(loggedUser, id);

        if (task is null || task.UserId != loggedUser.Id)
            throw new NotFoundException(ResourceErrorMessages.TASK_NOT_FOUND);

        task.UpdatedAt = DateTime.UtcNow;

        _mapper.Map(request, task);
        _taskUpdateOnlyRepository.Update(task);

        await _unitOfWork.Commit();
    }

    public void Validate(RequestRegisterTaskJson request)
    {
        var validator = new TaskValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors
                .Select(e => e.ErrorMessage)
                .ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
