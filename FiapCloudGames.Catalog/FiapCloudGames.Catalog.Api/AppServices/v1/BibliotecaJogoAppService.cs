using AutoMapper;
using FiapCloudGames.Catalog.Api.AppServices.v1.Interfaces;
using FiapCloudGames.Catalog.Application.Dtos;
using FiapCloudGames.Catalog.Domain.Entities;
using FiapCloudGames.Catalog.Domain.Services.v1;

namespace FiapCloudGames.Catalog.Api.AppServices.v1;

public sealed class BibliotecaJogoAppService(IBibliotecaJogoService bibliotecaJogoService, IMapper mapper) : IBibliotecaJogoAppService
{
    public async Task<IEnumerable<BibliotecaJogoDto>> ObterBibliotecasDeJogosAsync(CancellationToken cancellationToken)
        => mapper.Map<IEnumerable<BibliotecaJogoDto>>(await bibliotecaJogoService.ObterBibliotecasDeJogosAsync(cancellationToken));

    public async Task<BibliotecaJogoDto> ObterBibliotecaDeJogoPorIdAsync(Guid id, CancellationToken cancellationToken)
        => mapper.Map<BibliotecaJogoDto>(await bibliotecaJogoService.ObterBibliotecaDeJogoPorIdAsync(id, cancellationToken));

    public async Task<BibliotecaJogoDto> ObterBibliotecaDeJogosPorUsuarioIdAsync(Guid usuarioId, CancellationToken cancellationToken)
        => mapper.Map<BibliotecaJogoDto>(await bibliotecaJogoService.ObterBibliotecaDeJogosPorUsuarioIdAsync(usuarioId, cancellationToken));

    public async Task SolicitarCompraAsync(Guid usuarioId, JogoDto jogoDto, CancellationToken cancellationToken)
        => await bibliotecaJogoService.SolicitarCompraAsync(usuarioId, mapper.Map<Jogo>(jogoDto), cancellationToken);

    public async Task<BibliotecaJogoDto> RemoverJogoBibliotecaJogosAsync(Guid usuarioId, Guid idJogo, CancellationToken cancellationToken)
        => mapper.Map<BibliotecaJogoDto>(await bibliotecaJogoService.RemoverJogoBibliotecaJogosAsync(usuarioId, idJogo, cancellationToken));
}
