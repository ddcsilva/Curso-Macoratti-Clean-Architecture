using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Produtos.Commands;

namespace CleanArchitecture.Application.Mappings;

public class DTOToCommandMapping : Profile
{
    public DTOToCommandMapping()
    {
        CreateMap<ProdutoDTO, ProdutoCreateCommand>();
        CreateMap<ProdutoDTO, ProdutoUpdateCommand>();
    }
}