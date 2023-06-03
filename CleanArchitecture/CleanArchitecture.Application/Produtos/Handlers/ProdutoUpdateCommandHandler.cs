using CleanArchitecture.Application.Produtos.Commands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Produtos.Handlers;

public class ProdutoUpdateCommandHandler : IRequestHandler<ProdutoUpdateCommand, Produto>
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoUpdateCommandHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
    }

    public async Task<Produto> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
    {
        var produto = await _produtoRepository.ObterProdutoPorIdAsync(request.Id);

        if (produto == null)
        {
            throw new ApplicationException("Produto não encontrado");
        }
        else
        {
            produto.Atualizar(request.Nome, request.Descricao, request.Preco, request.Estoque, request.Imagem, request.CategoriaId);
            return await _produtoRepository.AtualizarAsync(produto);
        }
    }
}