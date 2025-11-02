using System.Threading.RateLimiting;

using Microsoft.AspNetCore.RateLimiting;

using OTManager.Api.Account.Extensions;
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
        services.AddAppIdentityAuthentication(configuration);
        services.AddDbContextExtension(configuration);
        services.AddSwaggerExtension(configuration);
        services.AddRepositoryExtension();
        services.AddUnitOfWorkExtension();
        services.AddControllers();
        services.AddAppServices();
        services.AddAppMappers();

        services.AddRateLimiter(static _ => _
            .AddFixedWindowLimiter("fixed", opt =>
            {
                opt.PermitLimit = 4;
                opt.Window = TimeSpan.FromSeconds(12);
                opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                opt.QueueLimit = 2;
            })
            .AddSlidingWindowLimiter("sliding", opt =>
            {
                opt.PermitLimit = 4;
                opt.Window = TimeSpan.FromSeconds(12);
                opt.SegmentsPerWindow = 2;
                opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                opt.QueueLimit = 2;
            })
            .AddTokenBucketLimiter("token", opt =>
            {
                opt.TokenLimit = 4;
                opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                opt.QueueLimit = 4;
                opt.ReplenishmentPeriod = TimeSpan.FromSeconds(5);
                opt.TokensPerPeriod = 2;
                opt.AutoReplenishment = true;
            })
            .AddConcurrencyLimiter("concurrency", opt =>
            {
                opt.PermitLimit = 5;
                opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                opt.QueueLimit = 3;
            }));

        return services;
    }
}
