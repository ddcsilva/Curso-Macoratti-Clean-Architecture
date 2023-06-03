using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;

    public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
    {
        _produtoRepository = produtoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProdutoDTO>> ObterProdutosAsync()
    {
        var produtos = await _produtoRepository.ObterProdutosAsync();
        return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
    }

    public async Task<ProdutoDTO> ObterProdutoPorIdAsync(int? id)
    {
        var produto = await _produtoRepository.ObterProdutoPorIdAsync(id);
        return _mapper.Map<ProdutoDTO>(produto);
    }

    public async Task<ProdutoDTO> ObterProdutoPorCategoriaAsync(int? categoriaId)
    {
        var produto = await _produtoRepository.ObterProdutoPorCategoriaAsync(categoriaId);
        return _mapper.Map<ProdutoDTO>(produto);
    }

    public async Task AdicionarAsync(ProdutoDTO produtoDTO)
    {
        var produto = _mapper.Map<Produto>(produtoDTO);
        await _produtoRepository.AdicionarAsync(produto);
    }

    public async Task AtualizarAsync(ProdutoDTO produtoDTO)
    {
        var produto = _mapper.Map<Produto>(produtoDTO);
        await _produtoRepository.AtualizarAsync(produto);
    }

    public async Task RemoverAsync(int? id)
    {
        var produto = _produtoRepository.ObterProdutoPorIdAsync(id).Result;
        await _produtoRepository.ExcluirAsync(produto);
    }
}