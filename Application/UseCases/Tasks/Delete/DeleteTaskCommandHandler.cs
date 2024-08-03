using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Tasks.Delete;

public sealed class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, int>
{
    private readonly ITaskRepository _repository;

    public DeleteTaskCommandHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var existingTask = await _repository.GetByIdAsync(request.Id);

        if (existingTask is null) return await Task.FromResult(0);

        var affectedRows = await _repository.DeleteAsync(existingTask);

        return await Task.FromResult(affectedRows);
    }
}