FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# Default non root user in Docker images .NET 8+
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Lab.Customers.Api/Lab.Customers.Api.csproj", "src/Lab.Customers.Api/"]
COPY ["src/Lab.Customers.Application/Lab.Customers.Application.csproj", "src/Lab.Customers.Application/"]
COPY ["src/Lab.Customers.Domain/Lab.Customers.Domain.csproj", "src/Lab.Customers.Domain/"]
COPY ["src/Lab.Core.Commons/Lab.Core.Commons.csproj", "src/Lab.Core.Commons/"]
COPY ["src/Lab.Telemetry/Lab.Telemetry.csproj", "src/Lab.Telemetry/"]
COPY ["src/Lab.Customers.Infra/Lab.Customers.Infra.csproj", "src/Lab.Customers.Infra/"]
COPY ["src/Lab.WebApi.Core/Lab.WebApi.Core.csproj", "src/Lab.WebApi.Core/"]
RUN dotnet restore "./src/Lab.Customers.Api/Lab.Customers.Api.csproj"
COPY . .
WORKDIR "/src/src/Lab.Customers.Api"
RUN dotnet build "./Lab.Customers.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Lab.Customers.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab.Customers.Api.dll"]