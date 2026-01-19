using FiapCloudGames.Catalog.Application.Interfaces.Messaging;
using FiapCloudGames.Catalog.Domain.Entities;
using FiapCloudGames.Catalog.Domain.Repositories.v1;
using FiapCloudGames.Catalog.Domain.Services.v1;

namespace FiapCloudGames.Catalog.Application.Services.v1;

public sealed class BibliotecaJogoService(
    IBibliotecaJogoRepository bibliotecaJogoRepository,
    IOrderEventPublisher orderEventPublisher) : IBibliotecaJogoService
{
    public async Task<IEnumerable<BibliotecaJogo>> ObterBibliotecasDeJogosAsync(CancellationToken cancellationToken)
        => await bibliotecaJogoRepository.ObterBibliotecasDeJogosAsync(cancellationToken);

    public async Task<BibliotecaJogo?> ObterBibliotecaDeJogoPorIdAsync(Guid id, CancellationToken cancellationToken)
        => await bibliotecaJogoRepository.ObterBibliotecaDeJogoPorIdAsync(id, cancellationToken);

    public async Task<BibliotecaJogo?> ObterBibliotecaDeJogosPorUsuarioIdAsync(Guid usuarioId, CancellationToken cancellationToken)
        => await bibliotecaJogoRepository.ObterBibliotecaDeJogosPorUsuarioIdAsync(usuarioId, cancellationToken);

    public async Task SolicitarCompraAsync(Guid usuarioId, Jogo jogo, CancellationToken cancellationToken)
        => await orderEventPublisher.PublishOrderPlacedEvent(new(usuarioId, jogo.Id, jogo.Preco!.Value), cancellationToken);

    public async Task<BibliotecaJogo> RemoverJogoBibliotecaJogosAsync(Guid usuarioId, Guid idJogo, CancellationToken cancellationToken)
        => await bibliotecaJogoRepository.RemoverJogoBibliotecaJogosAsync(usuarioId, idJogo, cancellationToken);
}