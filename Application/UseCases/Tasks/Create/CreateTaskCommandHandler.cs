using Domain.Interfaces;
using MediatR;
using Entities = Domain.Entities;

namespace Application.UseCases.Tasks.Create;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskCommandResult?>
{
    private readonly ITaskRepository _repository;

    public CreateTaskCommandHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateTaskCommandResult?> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        CreateTaskCommandResult? result = null;

        if (request.Description is null) return await Task.FromResult(result);

        var item = new Entities.Task
        {
            Description = request.Description!
        };

        var newTask = await _repository.CreateAsync(item);

        if (newTask is null) return await Task.FromResult(result);

        return await Task.FromResult(new CreateTaskCommandResult(newTask.Id, newTask.Description, newTask.IsCompleted));
    }
}
