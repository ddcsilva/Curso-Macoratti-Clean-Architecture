using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Produtos.Queries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
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

    // public async Task<ProdutoDTO> ObterProdutoPorIdAsync(int? id)
    // {
    //     var produto = await _produtoRepository.ObterProdutoPorIdAsync(id);
    //     return _mapper.Map<ProdutoDTO>(produto);
    // }

    // public async Task<ProdutoDTO> ObterProdutoPorCategoriaAsync(int? categoriaId)
    // {
    //     var produto = await _produtoRepository.ObterProdutoPorCategoriaAsync(categoriaId);
    //     return _mapper.Map<ProdutoDTO>(produto);
    // }

    // public async Task AdicionarAsync(ProdutoDTO produtoDTO)
    // {
    //     var produto = _mapper.Map<Produto>(produtoDTO);
    //     await _produtoRepository.AdicionarAsync(produto);
    // }

    // public async Task AtualizarAsync(ProdutoDTO produtoDTO)
    // {
    //     var produto = _mapper.Map<Produto>(produtoDTO);
    //     await _produtoRepository.AtualizarAsync(produto);
    // }

    // public async Task RemoverAsync(int? id)
    // {
    //     var produto = _produtoRepository.ObterProdutoPorIdAsync(id).Result;
    //     await _produtoRepository.ExcluirAsync(produto);
    // }
}