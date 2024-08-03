using FluentValidation;

namespace Application.UseCases.Tasks.Delete;

public sealed class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator()
    {
        RuleFor(v => v.Id)
           .NotNull()
               .WithMessage("Id é campo obrigatório.")
           .GreaterThan(0)
               .WithMessage("Id inválido.");
    }
}