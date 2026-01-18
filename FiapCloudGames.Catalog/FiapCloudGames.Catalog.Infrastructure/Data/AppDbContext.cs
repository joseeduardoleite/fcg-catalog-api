using FiapCloudGames.Catalog.Domain.Entities;
using FiapCloudGames.Catalog.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Infrastructure.Data;

[ExcludeFromCodeCoverage]
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Jogo> Jogos => Set<Jogo>();
    public DbSet<BibliotecaJogo> BibliotecasDeJogos => Set<BibliotecaJogo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new JogoMap());
        modelBuilder.ApplyConfiguration(new BibliotecaJogoMap());

        base.OnModelCreating(modelBuilder);
    }
}