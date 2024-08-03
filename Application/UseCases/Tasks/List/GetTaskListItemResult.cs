namespace Application.UseCases.Tasks.List;

public record GetTaskListItemResult(
    int Id,
    string Description,
    bool IsCompleted
);