using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Tasks.GetById;

public sealed class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, GetTaskByIdQueryResult?>
{
    private readonly ITaskRepository _repository;

    public GetTaskByIdQueryHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetTaskByIdQueryResult?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        GetTaskByIdQueryResult? result = null;

        if (request is null) return await Task.FromResult(result);

        var task = await _repository.GetByIdAsync(request.Id);

        if (task is null) return await Task.FromResult(result);

        result = new GetTaskByIdQueryResult(task.Id, task.Description, task.IsCompleted);

        return await Task.FromResult(result);
    }
}