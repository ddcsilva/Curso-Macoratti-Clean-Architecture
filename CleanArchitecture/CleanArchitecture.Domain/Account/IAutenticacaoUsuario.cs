namespace CleanArchitecture.Domain.Account;

public interface IAutenticacaoUsuario
{
    Task<bool> AutenticarAsync(string email, string senha);

    Task<bool> RegistrarAsync(string email, string senha);

    Task LogoutAsync();
}