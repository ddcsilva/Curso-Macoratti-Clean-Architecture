using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanArchitecture.API.Models;
using CleanArchitecture.Domain.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAutenticacaoUsuario _autenticacaoUsuario;
    private readonly IConfiguration _configuration;

    public TokenController(IAutenticacaoUsuario autenticacaoUsuario, IConfiguration configuration)
    {
        _autenticacaoUsuario = autenticacaoUsuario ?? throw new ArgumentNullException(nameof(autenticacaoUsuario));
        _configuration = configuration;
    }

    [HttpPost("Registro")]
    public async Task<ActionResult> Registro([FromBody] LoginModel loginModel)
    {
        var resultadoAutenticacao = await _autenticacaoUsuario.AutenticarAsync(loginModel.Email, loginModel.Senha);

        if (resultadoAutenticacao)
        {
            return Ok($"Usuário {loginModel.Email} registrado com sucesso.");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Login inválido.");
            return BadRequest(ModelState);
        }
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UsuarioToken>> Login([FromBody] LoginModel loginModel)
    {
        var resultadoAutenticacao = await _autenticacaoUsuario.AutenticarAsync(loginModel.Email, loginModel.Senha);

        if (resultadoAutenticacao)
        {
            return GerarToken(loginModel);
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Login inválido.");
            return BadRequest(ModelState);
        }
    }

    private UsuarioToken GerarToken(LoginModel loginModel)
    {
        // Declaração de Claims - Informações do usuário
        var claims = new[]
        {
            new Claim("email", loginModel.Email),
            new Claim("meuValor", "O que eu quiser"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Geração da Chave de Privada para Assinar o Token
        var chavePrivada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

        // Geração da Assinatura Digital do Token
        var credenciais = new SigningCredentials(chavePrivada, SecurityAlgorithms.HmacSha256);

        // Definição do Tempo de Expiração do Token
        var expiracao = DateTime.UtcNow.AddMinutes(10);

        // Geração do Token - JWT
        JwtSecurityToken token = new JwtSecurityToken(
            // Definição do Emissor do Token
            issuer: _configuration["Jwt:Issuer"],
            // Definição do Destinatário do Token
            audience: _configuration["Jwt:Audience"],
            // Definição das Claims do Token
            claims: claims,
            // Definição do Tempo de Expiração do Token
            expires: expiracao,
            // Definição da Chave de Assinatura do Token
            signingCredentials: credenciais
        );

        // Retorno do Token
        return new UsuarioToken
        {
            // Definição do Token
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            // Definição do Tempo de Expiração do Token
            Expiracao = expiracao
        };
    }
}