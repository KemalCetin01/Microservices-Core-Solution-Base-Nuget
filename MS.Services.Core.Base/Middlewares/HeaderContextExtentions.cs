using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MS.Services.Core.Base.Dtos;

namespace MS.Services.Core.Base.Middlewares;

public static class HeaderContextExtentions
{
    public static IApplicationBuilder AddHeaderContextMiddleware(this IApplicationBuilder appBuilder)
    {
        appBuilder.UseMiddleware<HeaderContextMiddleware>();

        return appBuilder;
    }

    public static void AddHeaderContext(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<HeaderContext>();
    }
}