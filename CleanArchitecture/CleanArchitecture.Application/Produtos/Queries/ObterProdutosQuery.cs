using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Produtos.Queries
{
    public class ObterProdutosQuery : IRequest<IEnumerable<Produto>> { }
}