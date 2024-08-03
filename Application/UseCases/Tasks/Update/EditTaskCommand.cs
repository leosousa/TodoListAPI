using MediatR;

namespace Application.UseCases.Tasks.Update;

public record EditTaskCommand : IRequest<EditTaskCommandResult?>
{
    public required int Id { get; set; }
    public required string Description { get; set; }
    public required bool IsCompleted { get; set; }
}
