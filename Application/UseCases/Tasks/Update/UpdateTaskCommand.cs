using MediatR;

namespace Application.UseCases.Tasks.Update;

public record UpdateTaskCommand : IRequest<UpdateTaskCommandResult?>
{
    public required int Id { get; set; }
    public required string Description { get; set; }
    public required bool IsCompleted { get; set; }
}
