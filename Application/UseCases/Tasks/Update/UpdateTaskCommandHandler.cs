using Application.UseCases.Tasks.Create;
using Domain.Interfaces;
using MediatR;
using Entities = Domain.Entities;

namespace Application.UseCases.Tasks.Update;

public sealed class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, UpdateTaskCommandResult?>
{
    private readonly ITaskRepository _repository;

    public UpdateTaskCommandHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateTaskCommandResult?> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        UpdateTaskCommandResult? result = null;

        if (request is null) return await Task.FromResult(result);

        var existingTask = await _repository.GetByIdAsync(request.Id);

        if (existingTask == null) return await Task.FromResult(result);

        existingTask.Description = request.Description;
        existingTask.IsCompleted = request.IsCompleted;

        var updatedTask = await _repository.UpdateAsync(existingTask);

        if (updatedTask is null) return await Task.FromResult(result);

        return await Task.FromResult(new UpdateTaskCommandResult(updatedTask.Id, updatedTask.Description, updatedTask.IsCompleted));
    }
}