using CleanArchitecture.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

public class ContaController : Controller
{
    private readonly IAutenticacaoUsuario _autenticacaoUsuario;

    public ContaController(IAutenticacaoUsuario autenticacaoUsuario)
    {
        _autenticacaoUsuario = autenticacaoUsuario;
    }
}