using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> ObterProdutosAsync();
    Task<Produto> ObterProdutoPorIdAsync(int? id);

    Task<Produto> ObterProdutoPorCategoriaAsync(int? categoriaId);

    Task<Produto> AdicionarAsync(Produto produto);
    Task<Produto> AtualizarAsync(Produto produto);
    Task<Produto> ExcluirAsync(Produto produto);
}