using MediatR;

namespace Application.UseCases.Tasks.GetById;

public record GetTaskByIdQuery : IRequest<GetTaskByIdQueryResult>
{
    public int Id { get; set; }
}
