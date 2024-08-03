namespace Application.UseCases.Tasks.Update;

public record EditTaskCommandResult(
    int Id,
    string Description,
    bool IsCompleted
);