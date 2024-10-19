using FluentValidation;
using TaskManager.Communication.Requests;
using TaskManager.Exception.Resource;

namespace TaskManager.Application.UseCases.Tasks.Validator;

public class TaskValidator : AbstractValidator<RequestRegisterTaskJson>
{
    public TaskValidator()
    {
        RuleFor(e => e.Title)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.TITLE_REQUIRED);

        RuleFor(e => e.Category)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.CATEGORY_REQUIRED);
    }
}
