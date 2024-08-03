using Application.UseCases.Tasks.Create;
using Domain.Interfaces;
using MediatR;
using Entities = Domain.Entities;

namespace Application.UseCases.Tasks.Update;

public sealed class EditTaskCommandHandler : IRequestHandler<EditTaskCommand, EditTaskCommandResult?>
{
    private readonly ITaskRepository _repository;

    public EditTaskCommandHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<EditTaskCommandResult?> Handle(EditTaskCommand request, CancellationToken cancellationToken)
    {
        EditTaskCommandResult? result = null;

        var existingTask = await _repository.GetByIdAsync(request.Id);

        if (existingTask == null) return await Task.FromResult(result);

        existingTask.Description = request.Description;
        existingTask.IsCompleted = request.IsCompleted;

        var updatedTask = await _repository.UpdateAsync(existingTask);

        if (updatedTask is null) return await Task.FromResult(result);

        return await Task.FromResult(new EditTaskCommandResult(updatedTask.Id, updatedTask.Description, updatedTask.IsCompleted));
    }
}