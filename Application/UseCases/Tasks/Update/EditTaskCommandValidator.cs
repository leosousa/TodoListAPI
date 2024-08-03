using FluentValidation;

namespace Application.UseCases.Tasks.Update;

public class EditTaskCommandValidator : AbstractValidator<EditTaskCommand>
{
    public EditTaskCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
                .WithMessage("Id é campo obrigatório.")
            .GreaterThan(0)
                .WithMessage("Id inválido.");

        RuleFor(v => v.Description)
            .NotEmpty()
                .WithMessage("Descrição é campo obrigatório.")
            .MaximumLength(255)
                .WithMessage("Descrição não pode ultrapassar 255 caracteres.");
    }
}