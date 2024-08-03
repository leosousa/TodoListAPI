using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Tasks.List;

public sealed class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, GetTaskListQueryResult>
{
    private readonly ITaskRepository _repository;

    public GetTaskListQueryHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetTaskListQueryResult> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
    {
        GetTaskListQueryResult result = new();

        var tasks = await _repository.GetAllAsync();

        if (tasks is null) return await Task.FromResult(result);

        tasks!.ToList().ForEach(task => {
            result.Add(new GetTaskListItemResult(task.Id, task.Description, task.IsCompleted));
        });

        return await Task.FromResult(result);
    }
}