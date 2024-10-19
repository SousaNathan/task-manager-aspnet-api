using FluentValidation;
using TaskManager.Communication.Requests;
using TaskManager.Exception.Resource;

namespace TaskManager.Application.UseCases.Users.Validator;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty()
                .WithMessage(ResourceErrorMessages.NAME_EMPTY);

        RuleFor(e => e.Email)
            .NotEmpty()
                .WithMessage(ResourceErrorMessages.EMAIL_EMPTY)
            .EmailAddress()
                .WithMessage(ResourceErrorMessages.EMAIL_INVALID);

        RuleFor(e => e.Password)
            .SetValidator(new PasswordValidator<RequestRegisterUserJson>());
    }
}
