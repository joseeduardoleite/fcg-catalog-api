using FiapCloudGames.Catalog.Application.Interfaces.Messaging;
using FiapCloudGames.Catalog.Domain.Events;
using MassTransit;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Infrastructure.Messaging;

[ExcludeFromCodeCoverage]
public class OrderEventPublisher(IPublishEndpoint publishEndpoint) : IOrderEventPublisher
{
    public async Task PublishOrderPlacedEvent(OrderPlacedEvent orderPlacedEvent, CancellationToken cancellationToken)
        => await publishEndpoint.Publish(orderPlacedEvent, cancellationToken);
}