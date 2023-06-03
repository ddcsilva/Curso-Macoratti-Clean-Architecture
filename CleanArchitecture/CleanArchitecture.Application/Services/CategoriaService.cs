using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IMapper _mapper;

    public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
    {
        _categoriaRepository = categoriaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoriaDTO>> ObterCategoriasAsync()
    {
        var categorias = await _categoriaRepository.ObterCategoriasAsync();
        return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
    }

    public async Task<CategoriaDTO> ObterCategoriaPorIdAsync(int? id)
    {
        var categoria = await _categoriaRepository.ObterCategoriaPorIdAsync(id);
        return _mapper.Map<CategoriaDTO>(categoria);
    }

    public async Task AdicionarAsync(CategoriaDTO categoriaDTO)
    {
        var categoria = _mapper.Map<Categoria>(categoriaDTO);
        await _categoriaRepository.AdicionarAsync(categoria);
    }

    public async Task AtualizarAsync(CategoriaDTO categoriaDTO)
    {
        var categoria = _mapper.Map<Categoria>(categoriaDTO);
        await _categoriaRepository.AtualizarAsync(categoria);
    }

    public async Task RemoverAsync(int? id)
    {
        var categoria = _categoriaRepository.ObterCategoriaPorIdAsync(id).Result;
        await _categoriaRepository.ExcluirAsync(categoria);
    }
}