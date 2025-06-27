using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MS.Services.Core.Base.Dtos;

namespace MS.Services.Core.Base.Handlers;

public interface IRequestBus
{
    public Task<TResponse> Send<TResponse>(IRequest<TResponse> command, CancellationToken token = default)
        where TResponse : IResponse;

    public Task Send(IRequest command, CancellationToken token = default);
}