using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Produtos.Commands;

public class ProdutoRemoveCommand : IRequest<Produto>
{
    public ProdutoRemoveCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}