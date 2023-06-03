using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
    {
        var categorias = await _categoriaService.ObterCategoriasAsync();

        if (categorias == null)
            return NotFound("Nenhuma categoria encontrada.");

        return Ok(categorias);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoriaDTO>> Get(int id)
    {
        var categoria = await _categoriaService.ObterCategoriaPorIdAsync(id);

        if (categoria == null)
            return NotFound("Categoria não encontrada.");

        return Ok(categoria);
    }
}