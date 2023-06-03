using CleanArchitecture.Application.Produtos.Queries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Produtos.Handlers;

public class ObterProdutoPorIdQueryHandler : IRequestHandler<ObterProdutoPorIdQuery, Produto>
{
    private readonly IProdutoRepository _produtoRepository;

    public ObterProdutoPorIdQueryHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Produto> Handle(ObterProdutoPorIdQuery request, CancellationToken cancellationToken)
    {
        return await _produtoRepository.ObterProdutoPorIdAsync(request.Id);
    }
}