using Lab.Customers.Api.Extensions;
using Lab.WebApi.Core.ApplicationIdentity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Lab.Customers.Api.Config;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppSettings>(configuration);
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IUserApp, UserApp>();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerConfig();
        services.RegisterServices(configuration);

        services.AddApiVersioning(config =>
        {
            config.ApiVersionReader = new UrlSegmentApiVersionReader();
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.DefaultApiVersion = new ApiVersion(1, 0);
        });

        // TODO: Config from context
        services.AddCors(options =>
        {
            options.AddPolicy("DefaultCors",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        services.AddHealthCheckConfig();

        return services;
    }

    public static WebApplication UseApiConfig(this WebApplication app)
    {
        app.UseSwaggerConfig();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.UseCors("DefaultCors");
        app.UseHealthCheckConfig();
        return app;
    }
}