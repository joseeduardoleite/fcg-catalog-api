using FiapCloudGames.Catalog.Application.Interfaces.Messaging;
using FiapCloudGames.Catalog.Domain.Events;
using MassTransit;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Infrastructure.Messaging;

[ExcludeFromCodeCoverage]
public class OrderEventPublisher(IPublishEndpoint publishEndpoint) : IOrderEventPublisher
{
    public Task PublishOrderPlacedEvent(OrderPlacedEvent orderPlacedEvent, CancellationToken cancellationToken)
        => publishEndpoint.Publish(orderPlacedEvent, cancellationToken);
}