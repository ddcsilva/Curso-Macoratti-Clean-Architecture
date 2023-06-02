using CleanArchitecture.Domain.Validations;

namespace CleanArchitecture.Domain.Entities;
public sealed class Categoria
{
    public Categoria(int id, string nome)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido");
        Id = id;
        Validar(nome);
    }

    public Categoria(string nome)
    {
        Validar(nome);
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }

    public ICollection<Produto> Produtos { get; set; }

    private void Validar(string nome)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome é obrigatório");
        DomainExceptionValidation.When(nome.Length < 3, "Nome inválido");
        Nome = nome;
    }
}