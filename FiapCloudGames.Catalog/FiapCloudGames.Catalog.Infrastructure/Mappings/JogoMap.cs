using FiapCloudGames.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Infrastructure.Mappings;

[ExcludeFromCodeCoverage]
public class JogoMap : IEntityTypeConfiguration<Jogo>
{
    public void Configure(EntityTypeBuilder<Jogo> builder)
    {
        builder.HasKey(j => j.Id);

        builder.Property(j => j.Nome)
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(j => j.Preco);

        builder.Property(j => j.Lancamento);

        builder.Property(j => j.CriadoEm);

        builder.Property(j => j.AtualizadoEm);
    }
}