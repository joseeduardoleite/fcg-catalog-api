using FiapCloudGames.Catalog.Domain.Entities;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace FiapCloudGames.Catalog.Infrastructure.Seed;

[ExcludeFromCodeCoverage]
public static class JogoSeed
{
    public static IEnumerable<Jogo> GetJogos()
        => new List<Jogo>()
        {
            new(
                nome: "Midnight Club 3: DUB Edition Remix",
                preco: 349.9m,
                lancamento: Data("11/04/2005")
            ),
            new(
                nome: "Grand Theft Auto: San Andreas",
                preco: 379.9m,
                lancamento: Data("26/10/2004")
            ),
            new(
                nome: "Need For Speed: Underground 2",
                preco: 329.9m,
                lancamento: Data("09/11/2004")
            ),
            new(
                nome: "Need For Speed: Underground",
                preco: 279.9m,
                lancamento: Data("03/10/2003")
            ),
            new(
                nome: "Grand Theft Auto IV",
                preco: 399.9m,
                lancamento: Data("29/04/2008")
            ),
            new(
                nome: "Grand Theft Auto V",
                preco: 499.9m,
                lancamento: Data("17/09/2013")
            ),
            new(
                nome: "Grand Theft Auto VI",
                preco: 599.9m,
                lancamento: Data("19/11/2026")
            ),
            new(
                nome: "Red Dead Redemption 2",
                preco: 349.9m,
                lancamento: Data("26/10/2018")
            ),
            new(
                nome: "The Last of Us",
                preco: 299.9m,
                lancamento: Data("14/06/2013")
            ),
            new(
                nome: "Gran Turismo 7",
                preco: 349.9m,
                lancamento: Data("04/03/2022")
            ),
            new(
                nome: "FIFA 13",
                preco: 179.9m,
                lancamento: Data("25/09/2012")
            ),
            new(
                nome: "Forza Horizon",
                preco: 229.9m,
                lancamento: Data("23/10/2012")
            ),
            new(
                nome: "Forza Motorsport 4",
                preco: 199.9m,
                lancamento: Data("11/10/2011")
            ),
            new(
                nome: "Shadow of the Colossus",
                preco: 249.9m,
                lancamento: Data("18/10/2005")
            )
        };

    private static DateTime Data(string data) =>
        DateTime.ParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture);
}