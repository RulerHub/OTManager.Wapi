using OTManager.App.Mappers;
using OTManager.App.Services;
using OTManager.Data.Context;
using OTManager.Data.Repositories;
using OTManager.Data.UoW;

namespace OTManager.Web.Extensions;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextExtension(configuration);
        services.AddRepositoryExtension();
        services.AddUnitOfWorkExtension();
        services.AddControllers();
        services.AddAppServices();
        services.AddAppMappers();

        services.AddLocalization();

        return services;
    }

    public static IApplicationBuilder AddLocalizationBuilder(this IApplicationBuilder app)
    {
        string[] supportedCultures = ["es-ES", "en-US"];

        var localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);

        app.UseRequestLocalization(localizationOptions);

        return app;
    }
}
