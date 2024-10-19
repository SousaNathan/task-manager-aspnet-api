using AutoMapper;
using TaskManager.Application.UseCases.Tasks.Validator;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;
using TaskManager.Domain.Repositories;
using TaskManager.Domain.Repositories.Task;
using TaskManager.Domain.Services.LoggedUser;
using TaskManager.Exception.ExceptionBase;

namespace TaskManager.Application.UseCases.Tasks.Create;

public class RegisterTaskUseCase : IRegisterTaskUseCase
{
    private readonly ITaskWriteOnlyRepository _taskWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;

    public RegisterTaskUseCase(
        ITaskWriteOnlyRepository taskWriteOnlyRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILoggedUser loggedUser)
    {
        _taskWriteOnlyRepository = taskWriteOnlyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }

    public async Task<ResponseRegisterTaskJson> Execute(RequestRegisterTaskJson request)
    {
        Validate(request);

        var loggerUser = await _loggedUser.Get();
        var task = _mapper.Map<Domain.Entities.Task>(request);

        task.IsCompleted = false;
        task.CreatedAt = DateTime.UtcNow;
        task.UpdatedAt = DateTime.UtcNow;
        task.UserId = loggerUser.Id;

        await _taskWriteOnlyRepository.Add(task);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisterTaskJson>(task);
    }

    private void Validate(RequestRegisterTaskJson request)
    {
        var validate = new TaskValidator()
            .Validate(request);

        if (!validate.IsValid)
        {
            var errorMessages = validate.Errors
            .Select(v => v.ErrorMessage)
            .ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
