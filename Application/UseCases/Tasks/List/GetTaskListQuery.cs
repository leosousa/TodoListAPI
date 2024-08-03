using MediatR;

namespace Application.UseCases.Tasks.List;

public record GetTaskListQuery : IRequest<GetTaskListQueryResult>
{
}