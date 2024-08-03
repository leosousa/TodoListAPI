using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Tasks.Delete;

public sealed class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
{
    private readonly ITaskRepository _repository;

    public DeleteTaskCommandHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var removedTask = false;

        if (request is null) return await Task.FromResult(removedTask);

        var existingTask = await _repository.GetByIdAsync(request.Id);

        if (existingTask is null) return await Task.FromResult(removedTask);

        removedTask = await _repository.DeleteAsync(existingTask);

        return await Task.FromResult(removedTask);
    }
}