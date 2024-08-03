using MediatR;

namespace Application.Base;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}