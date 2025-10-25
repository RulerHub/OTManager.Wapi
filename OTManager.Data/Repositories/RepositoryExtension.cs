using Microsoft.Extensions.DependencyInjection;

using OTManager.Data.Repositories.Implements;
using OTManager.Data.Repositories.Interface;

namespace OTManager.Data.Repositories;

public static class RepositoryExtension
{
    public static IServiceCollection AddRepositoryExtension(this IServiceCollection services)
    {
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IFactureRepository, FactureRepository>();
        services.AddScoped<IMaterialRepository, MaterialRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderServiceRepository, OrderServiceRepository>();
        services.AddScoped<IWorkerRepository, WorkerRepository>();
        return services;
    }
}
