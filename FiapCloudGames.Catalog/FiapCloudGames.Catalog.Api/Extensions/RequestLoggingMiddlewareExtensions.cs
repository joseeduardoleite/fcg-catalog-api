using FiapCloudGames.Catalog.Api.Middleware;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Api.Extensions;

[ExcludeFromCodeCoverage]
public static class RequestLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        => builder.UseMiddleware<RequestLoggingMiddleware>();
}