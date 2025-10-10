using Microsoft.Extensions.DependencyInjection;
using OTManager.App.Services.Interfaces;
using OTManager.App.Services.Implements;

namespace OTManager.App.Services;

public static class ServiceExtension
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderServiceAppService, OrderServiceAppService>();
        // Agrega aquí otros servicios según sea necesario
        return services;
    }
}
