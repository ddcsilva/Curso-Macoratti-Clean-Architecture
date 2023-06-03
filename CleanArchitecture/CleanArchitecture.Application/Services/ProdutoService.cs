using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Produtos.Commands;
using CleanArchitecture.Application.Produtos.Queries;
using MediatR;

namespace CleanArchitecture.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ProdutoService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ProdutoDTO>> ObterProdutosAsync()
    {
        var produtosQuery = new ObterProdutosQuery();

        if (produtosQuery == null)
            throw new ApplicationException("Erro ao obter produtos");

        var resultadoQuery = await _mediator.Send(produtosQuery);

        return _mapper.Map<IEnumerable<ProdutoDTO>>(resultadoQuery);
    }

    public async Task<ProdutoDTO> ObterProdutoPorIdAsync(int? id)
    {
        var produtoPorIdQuery = new ObterProdutoPorIdQuery(id.Value);

        if (produtoPorIdQuery == null)
            throw new ApplicationException("Erro ao obter produto");

        var resultadoQuery = await _mediator.Send(produtoPorIdQuery);

        return _mapper.Map<ProdutoDTO>(resultadoQuery);
    }

    public async Task AdicionarAsync(ProdutoDTO produtoDTO)
    {
        var produtoCriarCommand = _mapper.Map<ProdutoCreateCommand>(produtoDTO);
        await _mediator.Send(produtoCriarCommand);
    }

    public async Task AtualizarAsync(ProdutoDTO produtoDTO)
    {
        var produtoUpdateCommand = _mapper.Map<ProdutoUpdateCommand>(produtoDTO);
        await _mediator.Send(produtoUpdateCommand);
    }

    public async Task RemoverAsync(int? id)
    {
        var produtoRemoveCommand = new ProdutoRemoveCommand(id.Value);

        if (produtoRemoveCommand == null)
            throw new ApplicationException("Erro ao remover produto");

        await _mediator.Send(produtoRemoveCommand);
    }
}