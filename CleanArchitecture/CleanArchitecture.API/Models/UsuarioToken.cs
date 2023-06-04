namespace CleanArchitecture.API.Models;

public class UsuarioToken
{
    public string Token { get; set; }
    public DateTime Expiracao { get; set; }
}