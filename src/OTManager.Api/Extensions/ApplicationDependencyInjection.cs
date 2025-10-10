using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using OTManager.Data.Context;
using OTManager.Data.Repositories;
using OTManager.Data.UoW;
using OTManager.App.Services;

namespace OTManager.Api.Extensions;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextExtension(configuration);
        services.AddRepositoryExtension();
        services.AddUnitOfWorkExtension();
        services.AddAppServices(); // <-- Registro de servicios de aplicación
        return services;
    }
}
