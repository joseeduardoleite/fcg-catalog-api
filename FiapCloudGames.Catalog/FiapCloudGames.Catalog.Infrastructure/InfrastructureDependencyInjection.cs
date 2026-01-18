using FiapCloudGames.Catalog.Domain.Repositories.v1;
using FiapCloudGames.Catalog.Infrastructure.Auth;
using FiapCloudGames.Catalog.Infrastructure.Repositories.v1;
using FiapCloudGames.Catalog.Infrastructure.Seed;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FiapCloudGames.Catalog.Infrastructure;

[ExcludeFromCodeCoverage]
public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfraModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IJogoRepository, JogoRepository>();
        services.AddScoped<IBibliotecaJogoRepository, BibliotecaJogoRepository>();

        services.AddHostedService<DataSeederHostedService>();

        services.AddJwtAuthentication(configuration);

        return services;
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
        JwtSettings jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>()!;

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey!))
                };
            });

        return services;
    }
}