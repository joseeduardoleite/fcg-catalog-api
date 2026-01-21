using FiapCloudGames.Catalog.Domain.Entities;
using FiapCloudGames.Catalog.Infrastructure.Data;
using FiapCloudGames.Contracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Infrastructure.Messaging;

[ExcludeFromCodeCoverage]
public class UserCreatedEventConsumer(
    ILogger<UserCreatedEventConsumer> logger,
    AppDbContext context) : IConsumer<UserCreatedEvent>
{
    public async Task Consume(ConsumeContext<UserCreatedEvent> ctx)
    {
        var msg = ctx.Message;

        BibliotecaJogo bibliotecaJogo = new(
            usuarioId: msg.UsuarioId,
            jogos: []
        );

        context.BibliotecasDeJogos.Add(bibliotecaJogo);
        await context.SaveChangesAsync(ctx.CancellationToken);

        logger.LogInformation("Biblioteca da conta do usuário {NomeUsuario} cadastrada com sucesso", msg.Nome);
    }
}