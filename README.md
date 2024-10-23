# clean-arch-dotnet
dotnet ef database update -p .\src\Lab.Customers.Api\Lab.Customers.Api.csproj
dotnet ef migrations script -p .\src\Lab.Customers.Infra\ -s .\src\Lab.Customers.Api\Lab.Customers.Api.csproj -c CustomerDbContext -o .\deploy\init.sql

# Docker
docker-compose -f ./deploy/docker-compose.yaml up -d
docker-compose -f ./deploy/docker-compose.yaml build