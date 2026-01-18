using AutoMapper;
using FiapCloudGames.Catalog.Api.AppServices.v1.Interfaces;
using FiapCloudGames.Catalog.Application.Dtos;
using FiapCloudGames.Catalog.Domain.Entities;
using FiapCloudGames.Catalog.Domain.Services.v1;

namespace FiapCloudGames.Catalog.Api.AppServices.v1;

public sealed class JogoAppService(IJogoService jogoService, IMapper mapper) : IJogoAppService
{
    public async Task<IEnumerable<JogoDto>> ObterJogosAsync(CancellationToken cancellationToken)
        => mapper.Map<IEnumerable<JogoDto>>(await jogoService.ObterJogosAsync(cancellationToken));

    public async Task<IEnumerable<JogoDto>> ObterJogosPorAnoLancamentoAsync(int anoLancamento, CancellationToken cancellationToken)
        => mapper.Map<IEnumerable<JogoDto>>(await jogoService.ObterJogosPorAnoLancamentoAsync(anoLancamento, cancellationToken));

    public async Task<JogoDto> ObterJogoPorIdAsync(Guid id, CancellationToken cancellationToken)
        => mapper.Map<JogoDto>(await jogoService.ObterJogoPorIdAsync(id, cancellationToken));

    public async Task<JogoDto> ObterJogoPorNomeParcialAsync(string nome, CancellationToken cancellationToken)
        => mapper.Map<JogoDto>(await jogoService.ObterJogoPorNomeParcialAsync(nome, cancellationToken));

    public async Task<JogoDto> CriarJogoAsync(JogoDto jogoDto, CancellationToken cancellationToken)
        => mapper.Map<JogoDto>(await jogoService.CriarJogoAsync(mapper.Map<Jogo>(jogoDto), cancellationToken));

    public async Task<JogoDto> EditarJogoAsync(Guid id, JogoDto jogoDto, CancellationToken cancellationToken)
        => mapper.Map<JogoDto>(await jogoService.EditarJogoAsync(id, mapper.Map<Jogo>(jogoDto), cancellationToken));

    public async Task DeletarJogoAsync(Guid id, CancellationToken cancellationToken)
        => await jogoService.DeletarJogoAsync(id, cancellationToken);
}