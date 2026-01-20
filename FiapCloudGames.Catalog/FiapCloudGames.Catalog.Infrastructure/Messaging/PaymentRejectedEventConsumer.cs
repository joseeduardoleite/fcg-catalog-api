using FiapCloudGames.Contracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Infrastructure.Messaging;

[ExcludeFromCodeCoverage]
public class PaymentRejectedEventConsumer(ILogger<PaymentRejectedEventConsumer> logger) : IConsumer<PaymentRejectedEvent>
{
    public Task Consume(ConsumeContext<PaymentRejectedEvent> context)
    {
        logger.LogWarning(
            "Compra rejeitada. Usuario: {UsuarioId}, Jogo: {JogoId}, Motivo: {Motivo}",
            context.Message.UsuarioId,
            context.Message.JogoId,
            context.Message.Motivo
        );

        return Task.CompletedTask;
    }
}