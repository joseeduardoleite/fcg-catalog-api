using FiapCloudGames.Catalog.Domain.Entities;
using FiapCloudGames.Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Infrastructure.Seed;

[ExcludeFromCodeCoverage]
public sealed class DataSeederHostedService(
    ILogger<DataSeederHostedService> logger,
    IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (await context.Jogos.AnyAsync(cancellationToken))
            return;

        IEnumerable<Jogo> jogos = JogoSeed.GetJogos();

        await context.Jogos.AddRangeAsync(jogos, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Dados iniciais populados com sucesso!");
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
