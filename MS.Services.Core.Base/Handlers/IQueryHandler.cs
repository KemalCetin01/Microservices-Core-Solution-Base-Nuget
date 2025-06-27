using MediatR;
using MS.Services.Core.Base.Dtos;

namespace MS.Services.Core.Base.Handlers;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse> where TResponse : IResponse
{
}