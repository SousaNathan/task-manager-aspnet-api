using FluentValidation.Results;
using TaskManager.Application.UseCases.Users.Validator;
using TaskManager.Communication.Requests;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories.User;
using TaskManager.Domain.Repositories;
using TaskManager.Domain.Security.Cryptography;
using TaskManager.Domain.Services.LoggedUser;
using TaskManager.Exception.ExceptionBase;
using TaskManager.Exception.Resource;

namespace TaskManager.Application.UseCases.Users.ChangePassword;

public class ChangePasswordUseCase : IChangePasswordUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IUserUpdateOnlyRepository _userUpdateOnyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordEncripter _passwordEncripter;

    public ChangePasswordUseCase(
        ILoggedUser loggedUser,
        IUserUpdateOnlyRepository userUpdateOnyRepository,
        IUnitOfWork unitOfWork,
        IPasswordEncripter passwordEncripter)
    {
        _loggedUser = loggedUser;
        _userUpdateOnyRepository = userUpdateOnyRepository;
        _unitOfWork = unitOfWork;
        _passwordEncripter = passwordEncripter;
    }

    public async System.Threading.Tasks.Task Execute(RequestChangePasswordJson request)
    {
        var loggedUser = await _loggedUser.Get();

        Validate(request, loggedUser);

        var user = await _userUpdateOnyRepository.GetById(loggedUser.Id);
        user.Password = _passwordEncripter.Encript(user.Password);

        _userUpdateOnyRepository.Update(user);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestChangePasswordJson request, User loggedUser)
    {
        var validator = new ChangePasswordValidator();

        var result = validator.Validate(request);

        var passwordMarch = _passwordEncripter.Verify(request.Password, loggedUser.Password);

        if (!passwordMarch)
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.PASSWORD_ENTERED_DIFERENT_CURRENT_PASSWORD));

        if (!result.IsValid)
        {
            var errors = result.Errors
                .Select(e => e.ErrorMessage)
                .ToList();

            throw new ErrorOnValidationException(errors);
        }
    }
}
