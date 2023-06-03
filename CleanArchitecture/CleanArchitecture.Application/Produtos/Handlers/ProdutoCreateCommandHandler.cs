using CleanArchitecture.Application.Produtos.Commands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Produtos.Handlers;

public class ProdutoCreateCommandHandler : IRequestHandler<ProdutoCreateCommand, Produto>
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoCreateCommandHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Produto> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
    {
        var produto = new Produto(request.Nome, request.Descricao, request.Preco, request.Estoque, request.Imagem);

        if (produto == null)
        {
            throw new ApplicationException("Erro ao criar produto");
        }
        else
        {
            produto.CategoriaId = request.CategoriaId;
            return await _produtoRepository.AdicionarAsync(produto);
        }
    }
}