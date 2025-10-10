using OTManager.Data.Context;
using OTManager.Data.Repositories;
using OTManager.Data.UoW;

namespace OTManager.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependency(this IServiceCollection services, IConfiguration configuration)
    {
        // ToDo: Add services here
        services.AddControllers();
        //services.AddMapperExtension();
        services.AddSwaggerExtension(configuration);
        services.AddDbContextExtension(configuration);

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddRepositoryExtension();
        //services.AddServicesExtension();

        return services;
    }
}
