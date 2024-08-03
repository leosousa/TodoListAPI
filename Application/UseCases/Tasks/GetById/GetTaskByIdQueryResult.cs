namespace Application.UseCases.Tasks.GetById;

public record GetTaskByIdQueryResult(
    int Id,
    string Description,
    bool IsCompleted
);