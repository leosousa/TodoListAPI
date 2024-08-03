namespace Application.UseCases.Tasks.Create;

public record CreateTaskCommandResult(
    int Id,
    string Description,
    bool IsCompleted
);