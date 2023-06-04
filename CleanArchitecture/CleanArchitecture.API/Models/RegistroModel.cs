using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.API.Models;

public class RegistroModel
{
    [Required(ErrorMessage = "E-mail obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Senha obrigatória")]
    [StringLength(20, ErrorMessage = "A {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirmar senha")]
    [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
    public string ConfirmacaoSenha { get; set; }
}