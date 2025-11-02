using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

using OTManager.Api.Account.Services.Implement;
using OTManager.Api.Account.Services.Interface;
using OTManager.Data.Account;
using OTManager.Data.Context;

namespace OTManager.Api.Account.Extensions;

public static class IdentityExtension
{
    public static IServiceCollection AddAppIdentityAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        // Info: Add Identity
        services.AddIdentityCore<ApplicationUser>(opts =>
        {
            // ToDo: Cambiar para ambientes de producción
            opts.User.RequireUniqueEmail = true;
            opts.Password.RequiredLength = 8;
            opts.Password.RequireNonAlphanumeric = false;
            opts.Password.RequireUppercase = false;
        })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager<SignInManager<ApplicationUser>>()
            .AddDefaultTokenProviders();

        // Info: Configurar Jwt
        var jwtSettings = configuration.GetSection("Jwt");
        var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(opts =>
            {
                opts.RequireHttpsMetadata = true;
                opts.SaveToken = true;
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidateAudience = true,
                    ValidAudience = jwtSettings["Audience"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.FromMinutes(1),
                    NameClaimType = ClaimTypes.Name,
                    RoleClaimType = ClaimTypes.Role
                };
            });

        // Info: Permisos dinámicos 
        // !
        //services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        //services.AddScoped<IAuthorizationHandler, PermissionHandler>();

        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<ISessionContext, SessionContext>();
        services.AddHttpContextAccessor();

        return services;
    }
}
