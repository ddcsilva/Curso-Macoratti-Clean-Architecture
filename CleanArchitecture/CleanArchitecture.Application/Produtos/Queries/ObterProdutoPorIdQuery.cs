using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Produtos.Queries
{
    public class ObterProdutoPorIdQuery : IRequest<Produto>
    {
        public ObterProdutoPorIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}