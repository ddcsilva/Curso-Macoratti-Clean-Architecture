namespace CleanArchitecture.Domain.Entities;

public sealed class Produto
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }
    public string Imagem { get; private set; }
    
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
}