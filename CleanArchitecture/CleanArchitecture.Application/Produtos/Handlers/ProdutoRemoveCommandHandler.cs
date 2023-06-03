using CleanArchitecture.Application.Produtos.Commands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Produtos.Handlers;

public class ProdutoRemoveCommandHandler : IRequestHandler<ProdutoRemoveCommand, Produto>
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoRemoveCommandHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
    }

    public async Task<Produto> Handle(ProdutoRemoveCommand request, CancellationToken cancellationToken)
    {
        var produto = await _produtoRepository.ObterProdutoPorIdAsync(request.Id);

        if (produto == null)
        {
            throw new ApplicationException("Produto não encontrado");
        }
        else
        {
            var resultadoExclusao = await _produtoRepository.ExcluirAsync(produto);
            return resultadoExclusao;
        }
    }
}