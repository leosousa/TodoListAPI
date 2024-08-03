using MediatR;

namespace Application.UseCases.Tasks.Delete;

public record DeleteTaskCommand : IRequest<bool>
{
    public int Id { get; set; }
}