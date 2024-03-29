using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Interfaces;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoDTO>> ObterProdutosAsync();
    Task<ProdutoDTO> ObterProdutoPorIdAsync(int? id);
    Task AdicionarAsync(ProdutoDTO produtoDTO);
    Task AtualizarAsync(ProdutoDTO produtoDTO);
    Task RemoverAsync(int? id);
}