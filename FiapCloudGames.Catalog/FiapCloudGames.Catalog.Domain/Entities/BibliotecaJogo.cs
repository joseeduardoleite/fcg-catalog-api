namespace FiapCloudGames.Catalog.Domain.Entities;

public class BibliotecaJogo
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }

    public virtual ICollection<Jogo> Jogos { get; set; } = [];

    public BibliotecaJogo() { }

    public BibliotecaJogo(Guid usuarioId, ICollection<Jogo> jogos)
    {
        Id = Guid.NewGuid();
        UsuarioId = usuarioId;
        Jogos = jogos;
    }
}