using MediatR;

namespace Application.Base;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}