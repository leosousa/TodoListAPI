using MediatR;
using System.Net;

namespace Application.UseCases.Tasks.Create;

public sealed class CreateTaskCommand : IRequest<int>
{
    public required string Description { get; set; }
}
