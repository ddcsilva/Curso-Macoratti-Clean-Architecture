using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchitecture.WebUI.Controllers;

public class ProdutosController : Controller
{
    private readonly IProdutoService _produtoService;
    private readonly ICategoriaService _categoriaService;

    public ProdutosController(IProdutoService produtoService, ICategoriaService categoriaService)
    {
        _produtoService = produtoService;
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var produtos = await _produtoService.ObterProdutosAsync();
        return View(produtos);
    }

    [HttpGet]
    public async Task<IActionResult> Criar()
    {
        ViewBag.Categorias = new SelectList(await _categoriaService.ObterCategoriasAsync(), "Id", "Nome");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Criar(ProdutoDTO produtoDTO)
    {
        if (ModelState.IsValid)
        {
            await _produtoService.AdicionarAsync(produtoDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(produtoDTO);
    }
}