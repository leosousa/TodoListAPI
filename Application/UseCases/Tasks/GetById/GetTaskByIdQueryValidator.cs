using FluentValidation;

namespace Application.UseCases.Tasks.GetById;

public sealed class GetTaskByIdQueryValidator : AbstractValidator<GetTaskByIdQuery>
{
    public GetTaskByIdQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
                .WithMessage("Id é campo obrigatório.")
            .GreaterThan(0)
                .WithMessage("Id inválido.");
    }
}