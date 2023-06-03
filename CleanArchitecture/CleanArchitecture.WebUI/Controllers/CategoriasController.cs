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
}