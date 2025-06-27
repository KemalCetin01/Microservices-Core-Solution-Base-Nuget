using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MS.Services.Core.Base.Handlers;

namespace MS.Services.Core.Base.IoC;

public static class ServiceExtensions
{
    public static void AddApiLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IRequestBus, RequestBus>();
        serviceCollection.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddServices(typeof(ITransientService), ServiceLifetime.Transient)
            .AddServices(typeof(IScopedService), ServiceLifetime.Scoped);
    }

    #region Private Methods

    private static IServiceCollection AddServices(this IServiceCollection services, Type interfaceType,
        ServiceLifetime lifetime)
    {
        var interfaceTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(t => interfaceType.IsAssignableFrom(t)
                        && t.IsClass && !t.IsAbstract)
            .Select(t => new
            {
                Service = t.GetInterfaces().FirstOrDefault(),
                Implementation = t
            })
            .Where(t => t.Service is not null
                        && interfaceType.IsAssignableFrom(t.Service));

        foreach (var type in interfaceTypes) services.AddService(type.Service!, type.Implementation, lifetime);

        return services;
    }

    private static IServiceCollection AddService(this IServiceCollection services, Type serviceType,
        Type implementationType, ServiceLifetime lifetime)
    {
        return lifetime switch
        {
            ServiceLifetime.Transient => services.AddTransient(serviceType, implementationType),
            ServiceLifetime.Scoped => services.AddScoped(serviceType, implementationType),
            ServiceLifetime.Singleton => services.AddSingleton(serviceType, implementationType),
            _ => throw new ArgumentNullException("Invalid lifetime", nameof(lifetime))
        };
    }

    public static void AddBaseHealthChecks(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHealthChecks();
    }

    public static IApplicationBuilder UseBaseHealthChecks(this IApplicationBuilder appBuilder)
    {
        appBuilder.UseHealthChecks("/hc", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        return appBuilder;
    }

    #endregion
}