using MediatR;

namespace Application.UseCases.Tasks.Create;

public record CreateTaskCommand : IRequest<CreateTaskCommandResult?>
{
    public string? Description { get; set; }
}
