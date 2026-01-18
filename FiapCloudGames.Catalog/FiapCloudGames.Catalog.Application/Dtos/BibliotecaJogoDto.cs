namespace FiapCloudGames.Catalog.Application.Dtos;

public record BibliotecaJogoDto(
    Guid Id,
    Guid UsuarioId,
    string? UsuarioNome,
    IEnumerable<JogoDto>? Jogos
);