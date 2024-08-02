using Domain.Interfaces;
using MediatR;
using Entities = Domain.Entities;

namespace Application.UseCases.Tasks.Create;

public sealed class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
    private readonly ITaskRepository _repository;

    public CreateTaskCommandHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var item = new Entities.Task
        {
            Description = request.Description
        };

        return _repository.CreateAsync(item);
    }
}
