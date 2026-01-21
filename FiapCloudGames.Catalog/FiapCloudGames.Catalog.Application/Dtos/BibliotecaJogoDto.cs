namespace FiapCloudGames.Catalog.Application.Dtos;

public class BibliotecaJogoDto
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }
    public string? UsuarioNome { get; set; }
    public IEnumerable<JogoDto>? Jogos { get; set; }

    public BibliotecaJogoDto() { }

    public BibliotecaJogoDto(Guid usuarioId, string? usuarioNome, IEnumerable<JogoDto>? jogos)
    {
        Id = Guid.NewGuid();
        UsuarioId = usuarioId;
        UsuarioNome = usuarioNome;
        Jogos = jogos;
    }

    public BibliotecaJogoDto(Guid id, Guid usuarioId, string? usuarioNome, IEnumerable<JogoDto>? jogos)
    {
        Id = id;
        UsuarioId = usuarioId;
        UsuarioNome = usuarioNome;
        Jogos = jogos;
    }
}