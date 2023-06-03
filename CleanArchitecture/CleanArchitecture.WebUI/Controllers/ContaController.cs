using CleanArchitecture.Domain.Account;
using CleanArchitecture.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

public class ContaController : Controller
{
    private readonly IAutenticacaoUsuario _autenticacaoUsuario;

    public ContaController(IAutenticacaoUsuario autenticacaoUsuario)
    {
        _autenticacaoUsuario = autenticacaoUsuario;
    }

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        return View(new LoginViewModel()
        {
            ReturnUrl = returnUrl
        });
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid)
            return View(loginViewModel);

        var resultadoAutenticacao = await _autenticacaoUsuario.AutenticarAsync(loginViewModel.Email, loginViewModel.Senha);

        if (resultadoAutenticacao)
        {
            if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(loginViewModel.ReturnUrl);
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Login inválido.");
            return View(loginViewModel);
        }
    }

    [HttpGet]
    public IActionResult Registrar()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(RegistroViewModel registroViewModel)
    {
        if (!ModelState.IsValid)
            return View(registroViewModel);

        var resultado = await _autenticacaoUsuario.RegistrarAsync(registroViewModel.Email, registroViewModel.Senha);

        if (resultado)
        {
            return Redirect("/");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Erro ao registrar usuário.");
            return View(registroViewModel);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _autenticacaoUsuario.LogoutAsync();
        return Redirect("/Conta/Login");
    }
}