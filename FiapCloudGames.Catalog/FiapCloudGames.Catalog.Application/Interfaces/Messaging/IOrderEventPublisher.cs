using FiapCloudGames.Contracts.Events;

namespace FiapCloudGames.Catalog.Application.Interfaces.Messaging;

public interface IOrderEventPublisher
{
    Task PublishOrderPlacedEvent(OrderPlacedEvent orderPlacedEvent, CancellationToken cancellationToken);
}