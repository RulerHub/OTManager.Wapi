using Microsoft.Extensions.DependencyInjection;

using OTManager.App.Mappers.Implements;
using OTManager.App.Mappers.Interfaces;

namespace OTManager.App.Mappers;

public static class MapperExtension
{
    public static IServiceCollection AddAppMappers(this IServiceCollection services)
    {
        services.AddScoped<IClientMapper, ClientMapper>();
        services.AddScoped<IFactureMapper, FactureMapper>();
        services.AddScoped<IMaterialCostMapper, MaterialCostMapper>();
        services.AddScoped<IMaterialMapper, MaterialMapper>();
        services.AddScoped<IOrderMapper, OrderMapper>();
        services.AddScoped<IServiceCostMapper, ServiceCostMapper>();
        services.AddScoped<IWorkerCostMapper, WorkerCostMapper>();
        services.AddScoped<IWorkerMapper, WorkerMapper>();

        return services;
    }
}
