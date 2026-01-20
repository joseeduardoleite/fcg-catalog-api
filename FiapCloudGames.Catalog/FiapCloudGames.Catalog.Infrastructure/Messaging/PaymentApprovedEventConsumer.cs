using FiapCloudGames.Catalog.Domain.Repositories.v1;
using FiapCloudGames.Contracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Infrastructure.Messaging;

[ExcludeFromCodeCoverage]
public class PaymentApprovedEventConsumer(
    ILogger<PaymentApprovedEventConsumer> logger,
    IBibliotecaJogoRepository bibliotecaJogoRepository) : IConsumer<PaymentApprovedEvent>
{
    public async Task Consume(ConsumeContext<PaymentApprovedEvent> context)
    {
        var msg = context.Message;

        try
        {
            await bibliotecaJogoRepository.ConfirmarCompraAsync(
                msg.UsuarioId,
                msg.JogoId,
                context.CancellationToken
            );

            logger.LogInformation("Compra finalizada com sucesso");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro inesperado ao confirmar compra");
        }
    }
}