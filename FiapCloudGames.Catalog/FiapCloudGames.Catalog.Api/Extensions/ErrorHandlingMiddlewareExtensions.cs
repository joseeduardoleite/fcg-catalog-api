using FiapCloudGames.Catalog.Api.Middleware;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Api.Extensions;

[ExcludeFromCodeCoverage]
public static class ErrorHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        => builder.UseMiddleware<ErrorHandlingMiddleware>();
}
