using MediatR;
using MS.Services.Core.Base.Dtos;

namespace MS.Services.Core.Base.Handlers;

public interface ICommand<out TResponse> : IRequest<TResponse> where TResponse : IResponse
{
}

public interface ICommand : IRequest
{
}