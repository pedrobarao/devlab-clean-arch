using System.Data;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Lab.Customers.Api.Config;

public static class HealthCheckConfig
{
    private const string LivenessTag = "live";
    private const string ReadinessTag = "ready";

    public static IServiceCollection AddHealthCheckConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddCheck("live", () => HealthCheckResult.Healthy(), new[] { LivenessTag });

        services.AddHealthChecks()
            .AddNpgSql(configuration.GetConnectionString("DefaultConnection") ?? throw new NoNullAllowedException(),
                failureStatus: HealthStatus.Unhealthy,
                tags: [ReadinessTag]);

        return services;
    }

    public static WebApplication UseHealthCheckConfig(this WebApplication app)
    {
        app.MapHealthChecks("/health/live", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            Predicate = check => check.Tags.Contains(LivenessTag)
        });

        app.MapHealthChecks("/health/ready", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            Predicate = check => check.Tags.Contains(ReadinessTag)
        });

        app.MapHealthChecksUI();

        return app;
    }
}