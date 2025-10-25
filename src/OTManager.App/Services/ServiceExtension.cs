using Microsoft.Extensions.DependencyInjection;

using OTManager.App.Services.Implements;
using OTManager.App.Services.Interfaces;

namespace OTManager.App.Services;

public static class ServiceExtension
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IFactureService, FactureService>();
        services.AddScoped<IMaterialService, MaterialService>();
        services.AddScoped<IOrderServiceAppService, OrderServiceAppService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IWorkerService, WorkerService>();

        return services;
    }
}
