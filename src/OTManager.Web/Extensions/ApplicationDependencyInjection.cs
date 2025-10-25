using System.Net;

using Microsoft.FluentUI.AspNetCore.Components;

namespace OTManager.Web.Extensions;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRazorComponents()
    .AddInteractiveServerComponents();
        services.AddFluentUIComponents();

        services.AddLocalization();
        services.AddControllers();

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
