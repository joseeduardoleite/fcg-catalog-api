using FiapCloudGames.Catalog.Domain.Entities;
using FiapCloudGames.Catalog.Domain.Repositories.v1;
using FiapCloudGames.Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Infrastructure.Repositories.v1;

[ExcludeFromCodeCoverage]
public sealed class BibliotecaJogoRepository(
    AppDbContext context,
    IJogoRepository jogoRepository) : IBibliotecaJogoRepository
{
    public async Task<IEnumerable<BibliotecaJogo>> ObterBibliotecasDeJogosAsync(CancellationToken cancellationToken)
        => await context.BibliotecasDeJogos
            .AsNoTracking()
            .Include(b => b.Jogos)
            .ToListAsync(cancellationToken);

    public async Task<BibliotecaJogo?> ObterBibliotecaDeJogoPorIdAsync(Guid id, CancellationToken cancellationToken)
        => await context.BibliotecasDeJogos
            .AsNoTracking()
            .Include(b => b.Jogos)
            .FirstOrDefaultAsync(biblioteca => biblioteca.Id == id, cancellationToken);

    public async Task<BibliotecaJogo?> ObterBibliotecaDeJogosPorUsuarioIdAsync(Guid usuarioId, CancellationToken cancellationToken)
        => await context.BibliotecasDeJogos
            .AsNoTracking()
            .Include(b => b.Jogos)
            .FirstOrDefaultAsync(biblioteca => biblioteca.UsuarioId == usuarioId, cancellationToken);

    public async Task<BibliotecaJogo> ConfirmarCompraAsync(Guid usuarioId, Guid jogoId, CancellationToken cancellationToken)
    {
        BibliotecaJogo? biblioteca = await ObterBibliotecaDeJogosPorUsuarioIdAsync(usuarioId, cancellationToken);

        if (biblioteca is null)
        {
            biblioteca = new BibliotecaJogo(
                usuarioId: usuarioId,
                jogos: []
            );

            await context.BibliotecasDeJogos.AddAsync(biblioteca, cancellationToken);
        }

        if (biblioteca.Jogos.Any(jogo => jogo.Id == jogoId))
            throw new InvalidOperationException("Jogo já existe na biblioteca");

        Jogo jogo = await jogoRepository.ObterJogoPorIdAsync(jogoId, cancellationToken)
            ?? throw new KeyNotFoundException("Jogo não encontrado no catálogo");

        biblioteca.Jogos.Add(jogo);

        await context.SaveChangesAsync(cancellationToken);

        return biblioteca;

    }

    public async Task<BibliotecaJogo> RemoverJogoBibliotecaJogosAsync(Guid usuarioId, Guid jogoId, CancellationToken cancellationToken)
    {
        BibliotecaJogo biblioteca = await ObterBibliotecaDeJogosPorUsuarioIdAsync(usuarioId, cancellationToken)
            ?? throw new KeyNotFoundException("Biblioteca não encontrada");

        Jogo jogo = biblioteca.Jogos.FirstOrDefault(jogo => jogo.Id == jogoId)
            ?? throw new KeyNotFoundException("Jogo não encontrado na biblioteca");

        biblioteca.Jogos.Remove(jogo);

        await context.SaveChangesAsync(cancellationToken);

        return biblioteca;
    }
}