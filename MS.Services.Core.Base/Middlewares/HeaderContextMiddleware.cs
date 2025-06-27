using System.Globalization;
using Microsoft.AspNetCore.Http;
using MS.Services.Core.Base.Dtos;

namespace MS.Services.Core.Base.Middlewares;

public class HeaderContextMiddleware
{
    private readonly RequestDelegate _next;

    public HeaderContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, HeaderContext headerContext)
    {
        if (context.Request.Headers.TryGetValue("ODRefId", out var identityRefId))
            headerContext.ODRefId = Guid.TryParse(identityRefId, out var odRefId) ? odRefId : null;

        headerContext.Locale = CultureInfo.CurrentCulture.Parent.Name.ToLower();
        await _next(context);
    }
}