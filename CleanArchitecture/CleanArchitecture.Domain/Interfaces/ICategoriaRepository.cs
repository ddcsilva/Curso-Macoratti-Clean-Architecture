using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> ObterCategoriasAsync();
    Task<Categoria> ObterCategoriaPorIdAsync(int? id);

    Task<Categoria> AdicionarAsync(Categoria categoria);
    Task<Categoria> AtualizarAsync(Categoria categoria);
    Task<Categoria> ExcluirAsync(Categoria categoria);
}