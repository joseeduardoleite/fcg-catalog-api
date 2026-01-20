FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore FiapCloudGames.Catalog/FiapCloudGames.Catalog.Api/FiapCloudGames.Catalog.Api.csproj
RUN dotnet publish FiapCloudGames.Catalog/FiapCloudGames.Catalog.Api/FiapCloudGames.Catalog.Api.csproj \
    -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "FiapCloudGames.Catalog.Api.dll"]
