using FiapCloudGames.Catalog.Application.Mappers;
using FiapCloudGames.Catalog.Application.Services.v1;
using FiapCloudGames.Catalog.Domain.Services.v1;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Application;

[ExcludeFromCodeCoverage]
public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddScoped<IJogoService, JogoService>();
        services.AddScoped<IBibliotecaJogoService, BibliotecaJogoService>();

        services.AddAutoMapper(mapperConfigurationExpression =>
        {
            mapperConfigurationExpression.AddProfile(typeof(JogoMapper));
            mapperConfigurationExpression.AddProfile(typeof(BibliotecaJogoMapper));
        });

        return services;
    }
}