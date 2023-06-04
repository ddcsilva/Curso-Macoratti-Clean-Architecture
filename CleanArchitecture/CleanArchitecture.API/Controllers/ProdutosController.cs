using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutosController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
    {
        var produtos = await _produtoService.ObterProdutosAsync();

        if (produtos == null)
            return NotFound("Nenhum produto encontrado.");

        return Ok(produtos);
    }

    [HttpGet("{id:int}", Name = "ObterProduto")]
    public async Task<ActionResult<ProdutoDTO>> Get(int id)
    {
        var produto = await _produtoService.ObterProdutoPorIdAsync(id);

        if (produto == null)
            return NotFound("Produto não encontrado.");

        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDTO)
    {
        if (produtoDTO == null)
            return BadRequest("Produto inválido.");

        await _produtoService.AdicionarAsync(produtoDTO);

        return new CreatedAtRouteResult("ObterProduto", new { id = produtoDTO.Id }, produtoDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] ProdutoDTO produtoDTO)
    {
        if (id != produtoDTO.Id)
            return BadRequest("Produto inválido.");

        if (produtoDTO == null)
            return BadRequest("Produto inválido.");

        await _produtoService.AtualizarAsync(produtoDTO);

        return Ok(produtoDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ProdutoDTO>> Delete(int id)
    {
        var produtoDTO = await _produtoService.ObterProdutoPorIdAsync(id);

        if (produtoDTO == null)
            return NotFound("Produto não encontrado.");

        await _produtoService.RemoverAsync(id);

        return Ok(produtoDTO);
    }
}