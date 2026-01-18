using FiapCloudGames.Catalog.Domain.Entities;
using FiapCloudGames.Catalog.Domain.Repositories.v1;
using FiapCloudGames.Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Infrastructure.Repositories.v1;

[ExcludeFromCodeCoverage]
public sealed class JogoRepository(AppDbContext context) : IJogoRepository
{
    public async Task<IEnumerable<Jogo>> ObterJogosAsync(CancellationToken cancellationToken)
        => await context.Jogos.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IEnumerable<Jogo>> ObterJogosPorAnoLancamentoAsync(int anoLancamento, CancellationToken cancellationToken)
        => await context.Jogos
            .AsNoTracking()
            .Where(x => x.Lancamento.HasValue && x.Lancamento.Value.Year == anoLancamento)
            .ToListAsync(cancellationToken);

    public async Task<Jogo?> ObterJogoPorIdAsync(Guid id, CancellationToken cancellationToken)
        => await context.Jogos
            .AsNoTracking()
            .FirstOrDefaultAsync(jogo => jogo.Id == id, cancellationToken);

    public async Task<Jogo?> ObterJogoPorNomeParcialAsync(string nome, CancellationToken cancellationToken)
        => await context.Jogos
            .AsNoTracking()
            .FirstOrDefaultAsync(jogo =>
                EF.Functions.Like(jogo.Nome!, $"%{nome}%"),
                cancellationToken
            );

    public async Task<Jogo> CriarJogoAsync(Jogo jogo, CancellationToken cancellationToken)
    {
        Jogo jogoCriado = new(
            nome: jogo.Nome,
            preco: jogo.Preco,
            lancamento: jogo.Lancamento
        );

        await context.Jogos.AddAsync(jogoCriado, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return jogoCriado;
    }

    public async Task<Jogo?> EditarJogoAsync(Guid id, Jogo jogo, CancellationToken cancellationToken)
    {
        Jogo? jogoParaAtualizar = await ObterJogoPorIdAsync(id, cancellationToken)
            ?? throw new KeyNotFoundException("Jogo não encontrado");

        jogoParaAtualizar.Atualizar(jogo);

        context.Jogos.Update(jogoParaAtualizar);
        await context.SaveChangesAsync(cancellationToken);

        return jogoParaAtualizar;
    }

    public async Task DeletarJogoAsync(Guid id, CancellationToken cancellationToken)
    {
        Jogo? jogoParaDeletar = await ObterJogoPorIdAsync(id, cancellationToken) ??
            throw new KeyNotFoundException("Jogo não encontrado");

        context.Jogos.Remove(jogoParaDeletar);
        await context.SaveChangesAsync(cancellationToken);
    }
}