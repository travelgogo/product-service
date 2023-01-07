# product-service
From Infastructure
Migration: dotnet ef migrations add -s ../GoGo.Product.Api/GoGo.Product.Api.csproj -o Data/Migrations InitDb
Update db: dotnet ef database update --startup-project ../GoGo.Product.Api/GoGo.Product.Api.csproj