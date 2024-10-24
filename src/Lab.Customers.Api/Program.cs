using Lab.Customers.Api.Config;
using Lab.Customers.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiConfig(builder.Configuration);

var app = builder.Build();
app.UseApiConfig();

app.Run();