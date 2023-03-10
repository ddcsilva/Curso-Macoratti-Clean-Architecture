using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> ObterTodosAsync();
    Task<Produto> ObterPorIdAsync(int? id);

    Task<Produto> ObterProdutoComCategoriaAsync(int? id);

    Task<Produto> CriarAsync(Produto produto);
    Task<Produto> AtualizarAsync(Produto produto);
    Task<Produto> ExcluirAsync(Produto produto);
}
