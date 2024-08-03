namespace Application.UseCases.Tasks.Update;

public record UpdateTaskCommandResult(
    int Id,
    string Description,
    bool IsCompleted
);