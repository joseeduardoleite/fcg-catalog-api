using FiapCloudGames.Catalog.Domain.Events;
using FiapCloudGames.Catalog.Domain.Repositories.v1;
using MassTransit;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Infrastructure.Messaging;

[ExcludeFromCodeCoverage]
public class PaymentApprovedEventConsumer(
    IBibliotecaJogoRepository bibliotecaJogoRepository) : IConsumer<PaymentApprovedEvent>
{
    public async Task Consume(ConsumeContext<PaymentApprovedEvent> context)
    {
        var msg = context.Message;

        await bibliotecaJogoRepository.ConfirmarCompraAsync(
            msg.UsuarioId,
            msg.JogoId,
            context.CancellationToken
        );
    }
}