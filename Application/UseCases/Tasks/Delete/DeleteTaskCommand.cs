using MediatR;

namespace Application.UseCases.Tasks.Delete;

public record DeleteTaskCommand(int Id) : IRequest<int>;