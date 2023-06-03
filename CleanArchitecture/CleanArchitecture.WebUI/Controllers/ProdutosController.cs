using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchitecture.WebUI.Controllers;

public class ProdutosController : Controller
{
    private readonly IProdutoService _produtoService;
    private readonly ICategoriaService _categoriaService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProdutosController(IProdutoService produtoService, ICategoriaService categoriaService, IWebHostEnvironment webHostEnvironment)
    {
        _produtoService = produtoService;
        _categoriaService = categoriaService;
        _webHostEnvironment = webHostEnvironment;
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

    [HttpGet]
    public async Task<IActionResult> Editar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var produtoDTO = await _produtoService.ObterProdutoPorIdAsync(id);

        if (produtoDTO == null)
        {
            return NotFound();
        }

        ViewBag.Categorias = new SelectList(await _categoriaService.ObterCategoriasAsync(), "Id", "Nome");
        return View(produtoDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(int id, ProdutoDTO produtoDTO)
    {
        if (id != produtoDTO.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _produtoService.AtualizarAsync(produtoDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(produtoDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Remover(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var produtoDTO = await _produtoService.ObterProdutoPorIdAsync(id);

        if (produtoDTO == null)
        {
            return NotFound();
        }

        return View(produtoDTO);
    }

    [HttpPost, ActionName("Remover")]
    public async Task<IActionResult> ConfirmarRemocao(int id)
    {
        await _produtoService.RemoverAsync(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Detalhes(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var produtoDTO = await _produtoService.ObterProdutoPorIdAsync(id);

        if (produtoDTO == null)
        {
            return NotFound();
        }

        var wwwroot = _webHostEnvironment.WebRootPath;
        var imagem = Path.Combine(wwwroot, "imagens\\", produtoDTO.Imagem);
        var imagemExiste = System.IO.File.Exists(imagem);
        ViewBag.ExisteImagem = imagemExiste;

        return View(produtoDTO);
    }
}