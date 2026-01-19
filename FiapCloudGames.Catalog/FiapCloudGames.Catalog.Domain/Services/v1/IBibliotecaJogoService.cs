using FiapCloudGames.Catalog.Domain.Entities;

namespace FiapCloudGames.Catalog.Domain.Services.v1;

public interface IBibliotecaJogoService
{
    Task<IEnumerable<BibliotecaJogo>> ObterBibliotecasDeJogosAsync(CancellationToken cancellationToken);
    Task<BibliotecaJogo?> ObterBibliotecaDeJogoPorIdAsync(Guid id, CancellationToken cancellationToken);
    Task<BibliotecaJogo?> ObterBibliotecaDeJogosPorUsuarioIdAsync(Guid usuarioId, CancellationToken cancellationToken);
    Task SolicitarCompraAsync(Guid usuarioId, Jogo jogo, CancellationToken cancellationToken);
    Task<BibliotecaJogo> RemoverJogoBibliotecaJogosAsync(Guid usuarioId, Guid idJogo, CancellationToken cancellationToken);
}