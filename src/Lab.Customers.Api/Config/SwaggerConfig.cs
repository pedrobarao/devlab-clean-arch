namespace Lab.Customers.Api.Config;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        // services.AddSwaggerGen(c =>
        // {
        //     var provider = services.BuildServiceProvider()
        //         .GetRequiredService<IApiVersionDescriptionProvider>();
        //
        //     foreach (var description in provider.ApiVersionDescriptions)
        //     {
        //         c.SwaggerDoc(description.GroupName, new OpenApiInfo
        //         {
        //             Title = $"Customer API {description.ApiVersion}",
        //             Version = description.ApiVersion.ToString()
        //         });
        //     }
        //
        //     c.DocInclusionPredicate((docName, apiDesc) =>
        //     {
        //         var actionApiVersionModel =
        //             apiDesc.ActionDescriptor.GetApiVersionModel(ApiVersionMapping.Explicit |
        //                                                         ApiVersionMapping.Implicit);
        //         return actionApiVersionModel.DeclaredApiVersions.Any(v => $"v{v.ToString()}" == docName)
        //                || actionApiVersionModel.ImplementedApiVersions.Any(v => $"v{v.ToString()}" == docName);
        //     });
        // });
        return services;
    }

    public static WebApplication UseSwaggerConfig(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseReDoc(options => { options.RoutePrefix = "docs"; });
        }

        return app;
    }
}