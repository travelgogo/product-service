FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 7100

ENV ASPNETCORE_URLS=http://+:7100

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
# /src/ means a folder in container(RootFileSystemOfContainer/src/)
WORKDIR /src/
# COPY [<source from local machine related with DockerFile>, <des path in filesystem of container>]
COPY ["src/GoGo.Product.Api/", "./GoGo.Product.Api/"]
COPY ["src/GoGo.Product.Application/", "./GoGo.Product.Application/"]
COPY ["src/GoGo.Product.Domain/", "./GoGo.Product.Domain/"]
COPY ["src/GoGo.Product.Infastructure/", "./GoGo.Product.Infastructure/"]
COPY nuget.config .

WORKDIR "/src/GoGo.Product.Api"
RUN dotnet restore 
#COPY src/GoGo.Product.Api .
RUN dotnet build --no-restore -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GoGo.Product.Api.dll"]
