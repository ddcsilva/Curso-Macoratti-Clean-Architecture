using CleanArchitecture.Application.Produtos.Queries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Produtos.Handlers;

public class ObterProdutosQueryHandler : IRequestHandler<ObterProdutosQuery, IEnumerable<Produto>>
{
    private readonly IProdutoRepository _produtoRepository;

    public ObterProdutosQueryHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<IEnumerable<Produto>> Handle(ObterProdutosQuery request, CancellationToken cancellationToken)
    {
        return await _produtoRepository.ObterProdutosAsync();
    }
}