using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OTManager.Data.Context;

/// <summary>
/// Extensiones para la configuración de ApplicationDbContext en el contenedor de servicios.
/// </summary>
public static class DbContextExtension
{
    /// <summary>
    /// Agrega y configura ApplicationDbContext en el contenedor de servicios.
    /// </summary>
    /// <param name="services">El contenedor de servicios.</param>
    /// <param name="configuration">La configuración de la aplicación.</param>
    /// <param name="connectionStringName">Nombre de la cadena de conexión (por defecto "DefaultConnection").</param>
    /// <param name="optionsAction">Acción opcional para configurar opciones adicionales de ApplicationDbContext.</param>
    /// <returns>El contenedor de servicios.</returns>
    public static IServiceCollection AddDbContextExtension(
        this IServiceCollection services,
        IConfiguration configuration,
        string connectionStringName = "DefaultConnection",
        Action<DbContextOptionsBuilder>? optionsAction = null)
    {
        var connectionStringsSection = configuration.GetSection("ConnectionStrings");
        var connectionString = connectionStringsSection[connectionStringName];

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException($"Connection string '{connectionStringName}' not found or is empty.");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            optionsAction?.Invoke(options);
        });
        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }
}
