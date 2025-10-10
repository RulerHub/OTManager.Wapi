using Microsoft.Extensions.DependencyInjection;

namespace OTManager.Data.UoW;

public static class UoWExtension
{
    public static IServiceCollection AddUnitOfWorkExtension(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
