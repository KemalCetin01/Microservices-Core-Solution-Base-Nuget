using MediatR;
using MS.Services.Core.Base.Dtos;

namespace MS.Services.Core.Base.Handlers;

public class RequestBus : IRequestBus
{
    private readonly IMediator _mediator;

    public RequestBus(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> command, CancellationToken token = default)
        where TResponse : IResponse
    {
        return await _mediator.Send(command, token);
    }

    public async Task Send(IRequest command, CancellationToken token = default)
    {
        await _mediator.Send(command, token);
    }
}