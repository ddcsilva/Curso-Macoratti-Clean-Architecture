using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Interfaces;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaDTO>> ObterCategoriasAsync();
    Task<CategoriaDTO> ObterCategoriaPorIdAsync(int? id);

    Task AdicionarAsync(CategoriaDTO categoriaDTO);
    Task AtualizarAsync(CategoriaDTO categoriaDTO);
    Task RemoverAsync(int? id);
}