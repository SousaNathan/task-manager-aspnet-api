using FluentValidation;
using TaskManager.Communication.Requests;

namespace TaskManager.Application.UseCases.Users.Validator;

public class ChangePasswordValidator : AbstractValidator<RequestChangePasswordJson>
{
    public ChangePasswordValidator()
    {
        RuleFor(x => x.NewPassword)
            .SetValidator(new PasswordValidator<RequestChangePasswordJson>());
    }
}
