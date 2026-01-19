using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Domain.Events;

[ExcludeFromCodeCoverage]
public class OrderPlacedEvent
{
    public Guid UsuarioId { get; set; }
    public Guid JogoId { get; set; }
    public decimal? Preco { get; set; }

    public OrderPlacedEvent() { }

    public OrderPlacedEvent(Guid usuarioId, Guid jogoId, decimal? preco)
    {
        UsuarioId = usuarioId;
        JogoId = jogoId;
        Preco = preco;
    }
}