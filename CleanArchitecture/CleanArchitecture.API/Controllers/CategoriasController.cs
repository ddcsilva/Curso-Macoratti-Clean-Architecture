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

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public async Task<ActionResult<CategoriaDTO>> Get(int id)
    {
        var categoria = await _categoriaService.ObterCategoriaPorIdAsync(id);

        if (categoria == null)
            return NotFound("Categoria não encontrada.");

        return Ok(categoria);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
    {
        if (categoriaDTO == null)
            return BadRequest("Categoria inválida.");

        await _categoriaService.AdicionarAsync(categoriaDTO);

        return new CreatedAtRouteResult("ObterCategoria", new { id = categoriaDTO.Id }, categoriaDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDTO)
    {
        if (id != categoriaDTO.Id)
            return BadRequest("Categoria inválida.");

        if (categoriaDTO == null)
            return BadRequest("Categoria inválida.");

        await _categoriaService.AtualizarAsync(categoriaDTO);

        return Ok(categoriaDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CategoriaDTO>> Delete(int id)
    {
        var categoria = await _categoriaService.ObterCategoriaPorIdAsync(id);

        if (categoria == null)
            return NotFound("Categoria não encontrada.");

        await _categoriaService.RemoverAsync(id);

        return Ok(categoria);
    }
}