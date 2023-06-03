using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs;

public class ProdutoDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(3)]
    [MaxLength(100)]
    [Display(Name = "Nome")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatória")]
    [MinLength(5)]
    [MaxLength(200)]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O preço é obrigatório")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [Display(Name = "Preço")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "O estoque é obrigatório")]
    [Range(1, 9999)]
    [Display(Name = "Estoque")]
    public int Estoque { get; set; }

    [MaxLength(250)]
    [Display(Name = "Imagem do produto")]
    public string Imagem { get; set; }

    [Display(Name = "Categoria")]
    public int CategoriaId { get; set; }
    public CategoriaDTO Categoria { get; set; }
}