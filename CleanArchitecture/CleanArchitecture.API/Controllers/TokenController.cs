using CleanArchitecture.API.Models;
using CleanArchitecture.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAutenticacaoUsuario _autenticacaoUsuario;

    public TokenController(IAutenticacaoUsuario autenticacaoUsuario)
    {
        _autenticacaoUsuario = autenticacaoUsuario ?? throw new ArgumentNullException(nameof(autenticacaoUsuario));
    }

    [HttpPost("login")]
    public async Task<ActionResult<UsuarioToken>> Login([FromBody] LoginModel loginModel)
    {
        var resultadoAutenticacao = await _autenticacaoUsuario.AutenticarAsync(loginModel.Email, loginModel.Senha);

        if (resultadoAutenticacao)
        {
            // return GerarToken(loginModel);
            return Ok($"Usuário {loginModel.Email} autenticado com sucesso.");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Login inválido.");
            return BadRequest(ModelState);
        }
    }
}