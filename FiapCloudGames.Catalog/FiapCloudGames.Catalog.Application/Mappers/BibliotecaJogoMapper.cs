using AutoMapper;
using FiapCloudGames.Catalog.Application.Dtos;
using FiapCloudGames.Catalog.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace FiapCloudGames.Catalog.Application.Mappers;

[ExcludeFromCodeCoverage]
public sealed class BibliotecaJogoMapper : Profile
{
    public BibliotecaJogoMapper()
        => CreateMap<BibliotecaJogo, BibliotecaJogoDto>()
            .ReverseMap();
}