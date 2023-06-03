using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.WebUI.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "E-mail obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Senha obrigatória")]
    [StringLength(20, ErrorMessage = "A {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 10)]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    public string ReturnUrl { get; set; }
}