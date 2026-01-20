namespace FiapCloudGames.Catalog.Application.Dtos;

public class JogoDto
{
    public Guid? Id { get; set; }
    public string? Nome { get; set; }
    public DateTime? Lancamento { get; set; }
    public decimal? Preco { get; set; }

    public JogoDto() { }
}