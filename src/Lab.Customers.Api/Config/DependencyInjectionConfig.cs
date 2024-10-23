using Lab.Customers.Application.Interfaces;
using Lab.Customers.Application.UseCases;
using Lab.Customers.Domain.Repositories;
using Lab.Customers.Infra.Data;
using Lab.Customers.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lab.Customers.Api.Config;

public static class DependencyInjectionConfig
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterUseCases(services);
        RegisterInfraServices(services, configuration);

        return services;
    }

    private static void RegisterUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreateCustomerUseCase, CreateCustomerUseCase>();
        services.AddScoped<IGetCustomerUseCase, GetCustomerUseCase>();
        services.AddScoped<IListCustomerUseCase, ListCustomerUseCase>();
        services.AddScoped<IUpdateCustomerUseCase, UpdateCustomerUseCase>();
        services.AddScoped<IDeleteCustomerUseCase, DeleteCustomerUseCase>();
    }

    private static void RegisterInfraServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CustomerDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }
}