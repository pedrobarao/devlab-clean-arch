using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Lab.Customers.Api.Config;

public static class HealthCheckConfig
{
    public static IServiceCollection AddHealthCheckConfig(this IServiceCollection services)
    {
        services.AddHealthChecks();

        return services;
    }

    public static WebApplication UseHealthCheckConfig(this WebApplication app)
    {
        app.MapHealthChecks("/healthz/ready", new HealthCheckOptions
        {
            Predicate = healthCheck => healthCheck.Tags.Contains("ready")
        });

        app.MapHealthChecks("/healthz/live", new HealthCheckOptions
        {
            Predicate = _ => false
        });

        return app;
    }
}