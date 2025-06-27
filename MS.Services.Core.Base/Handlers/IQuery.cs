using MediatR;
using MS.Services.Core.Base.Dtos;

namespace MS.Services.Core.Base.Handlers;

public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : IResponse
{
}