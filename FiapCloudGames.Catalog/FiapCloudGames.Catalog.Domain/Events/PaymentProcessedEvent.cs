using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Domain.Events;

[ExcludeFromCodeCoverage]
public class PaymentProcessedEvent
{
    public Guid UsuarioId { get; set; }
    public Guid JogoId { get; set; }
    public string? Status { get; set; }
}
