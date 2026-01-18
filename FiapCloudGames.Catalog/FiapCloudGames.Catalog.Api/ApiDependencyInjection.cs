using FiapCloudGames.Catalog.Api.AppServices.v1;
using FiapCloudGames.Catalog.Api.AppServices.v1.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Api;

[ExcludeFromCodeCoverage]
public static class ApiDependencyInjection
{
    public static IServiceCollection AddApiModule(this IServiceCollection services)
    {
        services.AddScoped<IJogoAppService, JogoAppService>();
        services.AddScoped<IBibliotecaJogoAppService, BibliotecaJogoAppService>();

        return services;
    }
}