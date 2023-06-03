using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs;

public class CategoriaDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Nome { get; set; }
}