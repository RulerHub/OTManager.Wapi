using OTManager.App.Mappers;
using OTManager.App.Services;
using OTManager.Data.Context;
using OTManager.Data.Repositories;
using OTManager.Data.UoW;

namespace OTManager.Api.Extensions;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextExtension(configuration);
        services.AddSwaggerExtension(configuration);
        services.AddRepositoryExtension();
        services.AddUnitOfWorkExtension();
        services.AddControllers();
        services.AddAppServices();
        services.AddAppMappers();
        return services;
    }
}
