using CleanArchitecture.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infra.Data.Identity;

public class AutenticacaoUsuarioService : IAutenticacaoUsuario
{
    private readonly SignInManager<Usuario> _signInManager;
    private readonly UserManager<Usuario> _userManager;

    public AutenticacaoUsuarioService(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<bool> AutenticarAsync(string email, string senha)
    {
        var resultadoAutenticacao = await _signInManager.PasswordSignInAsync(email, senha, false, lockoutOnFailure: false);

        return resultadoAutenticacao.Succeeded;
    }

    public async Task<bool> RegistrarAsync(string email, string senha)
    {
        var usuario = new Usuario
        {
            UserName = email,
            Email = email
        };

        var resultadoRegistro = await _userManager.CreateAsync(usuario, senha);

        if (resultadoRegistro.Succeeded)
        {
            await _signInManager.SignInAsync(usuario, isPersistent: false);
        }

        return resultadoRegistro.Succeeded;
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}