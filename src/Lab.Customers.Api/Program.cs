using Lab.Customers.Api.Config;
using Lab.Customers.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiConfig(builder.Configuration);

var appSettings = builder.Configuration.Get<AppSettings>();

var app = builder.Build();

app.UseApiConfig();

app.Run();

public abstract partial class Program
{
}