namespace FiapCloudGames.Catalog.Application.Dtos;

public class JogoDto
{
    public Guid? Id { get; set; }
    public string? Nome { get; set; }
    public DateTime? Lancamento { get; set; }
    public decimal? Preco { get; set; }

    public JogoDto() { }

    public JogoDto(Guid? id, string? nome, DateTime? lancamento, decimal? preco)
    {
        Id = id;
        Nome = nome;
        Lancamento = lancamento;
        Preco = preco;
    }

    public JogoDto(string? nome, DateTime? lancamento, decimal? preco)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Lancamento = lancamento;
        Preco = preco;
    }
}