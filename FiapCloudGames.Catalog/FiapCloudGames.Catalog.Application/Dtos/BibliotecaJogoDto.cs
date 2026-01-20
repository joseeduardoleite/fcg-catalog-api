namespace FiapCloudGames.Catalog.Application.Dtos;

public class BibliotecaJogoDto
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }
    public string? UsuarioNome { get; set; }
    public IEnumerable<JogoDto>? Jogos { get; set; }

    public BibliotecaJogoDto() { }
}