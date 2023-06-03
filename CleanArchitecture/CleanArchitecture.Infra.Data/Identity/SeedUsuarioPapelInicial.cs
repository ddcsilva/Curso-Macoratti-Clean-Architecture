using CleanArchitecture.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infra.Data.Identity;

public class SeedUsuarioPapelInicial : ISeedUsuarioPapelInicial
{
    private readonly UserManager<Usuario> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedUsuarioPapelInicial(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void SeedUsuarios()
    {
        if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
        {
            Usuario usuario = new Usuario();
            usuario.UserName = "usuario@localhost";
            usuario.Email = "usuario@localhost";
            usuario.NormalizedUserName = "USUARIO@LOCALHOST";
            usuario.NormalizedEmail = "USUARIO@LOCALHOST";
            usuario.EmailConfirmed = true;
            usuario.LockoutEnabled = false;
            usuario.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _userManager.CreateAsync(usuario, "Usuario@123").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(usuario, "Usuario").Wait();
            }
        }

        if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
        {
            Usuario usuario = new Usuario();
            usuario.UserName = "admin@localhost";
            usuario.Email = "admin@localhost";
            usuario.NormalizedUserName = "ADMIN@LOCALHOST";
            usuario.NormalizedEmail = "ADMIN@LOCALHOST";
            usuario.EmailConfirmed = true;
            usuario.LockoutEnabled = false;
            usuario.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _userManager.CreateAsync(usuario, "Admin@123").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(usuario, "Admin").Wait();
            }
        }
    }

    public void SeedPapeis()
    {
        if (!_roleManager.RoleExistsAsync("Usuario").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Usuario";
            role.NormalizedName = "USUARIO";
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }

        if (!_roleManager.RoleExistsAsync("Admin").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Admin";
            role.NormalizedName = "ADMIN";
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }
    }
}