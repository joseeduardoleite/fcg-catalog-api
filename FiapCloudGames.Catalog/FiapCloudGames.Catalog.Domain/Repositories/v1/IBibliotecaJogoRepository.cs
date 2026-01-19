using FiapCloudGames.Catalog.Domain.Entities;

namespace FiapCloudGames.Catalog.Domain.Repositories.v1;

public interface IBibliotecaJogoRepository
{
    Task<IEnumerable<BibliotecaJogo>> ObterBibliotecasDeJogosAsync(CancellationToken cancellationToken);
    Task<BibliotecaJogo?> ObterBibliotecaDeJogoPorIdAsync(Guid id, CancellationToken cancellationToken);
    Task<BibliotecaJogo?> ObterBibliotecaDeJogosPorUsuarioIdAsync(Guid usuarioId, CancellationToken cancellationToken);
    Task<BibliotecaJogo> ConfirmarCompraAsync(Guid usuarioId, Guid jogoId, CancellationToken cancellationToken);
    Task<BibliotecaJogo> RemoverJogoBibliotecaJogosAsync(Guid usuarioId, Guid jogoId, CancellationToken cancellationToken);
}