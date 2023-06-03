using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Produtos.Commands;

public abstract class ProdutoCommand : IRequest<Produto>
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
    public string Imagem { get; set; }
    public int CategoriaId { get; set; }
}
