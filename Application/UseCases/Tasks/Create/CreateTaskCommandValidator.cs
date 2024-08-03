using FluentValidation;

namespace Application.UseCases.Tasks.Create;

public sealed class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(v => v.Description)
            .NotEmpty()
                .WithMessage("Descrição é campo obrigatório.")
            .MaximumLength(255)
                .WithMessage("Descrição não pode ultrapassar 255 caracteres.");
    }
}
