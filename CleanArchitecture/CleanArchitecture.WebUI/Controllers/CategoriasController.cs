using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

public class CategoriasController : Controller
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categorias = await _categoriaService.ObterCategoriasAsync();
        return View(categorias);
    }

    [HttpGet]
    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Criar(CategoriaDTO categoriaDTO)
    {
        if (ModelState.IsValid)
        {
            await _categoriaService.AdicionarAsync(categoriaDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(categoriaDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Editar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categoriaDTO = await _categoriaService.ObterCategoriaPorIdAsync(id.Value);

        if (categoriaDTO == null)
        {
            return NotFound();
        }

        return View(categoriaDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(CategoriaDTO categoriaDTO)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _categoriaService.AtualizarAsync(categoriaDTO);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(categoriaDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Remover(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categoriaDTO = await _categoriaService.ObterCategoriaPorIdAsync(id.Value);

        if (categoriaDTO == null)
        {
            return NotFound();
        }

        return View(categoriaDTO);
    }

    [HttpPost, ActionName("Remover")]
    public async Task<IActionResult> ConfirmarRemocao(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        await _categoriaService.RemoverAsync(id.Value);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Detalhes(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categoriaDTO = await _categoriaService.ObterCategoriaPorIdAsync(id.Value);

        if (categoriaDTO == null)
        {
            return NotFound();
        }

        return View(categoriaDTO);
    }
}