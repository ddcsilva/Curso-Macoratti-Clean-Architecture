using CleanArchitecture.Domain.Validations;

namespace CleanArchitecture.Domain.Entities;
public sealed class Categoria : BaseEntity
{
    public Categoria(int id, string nome)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido");
        Validar(nome);
        Id = id;
    }

    public Categoria(string nome)
    {
        Validar(nome);
    }

    public string Nome { get; private set; }

    public ICollection<Produto> Produtos { get; set; }

    public void Atualizar(string nome)
    {
        Validar(nome);
    }

    private void Validar(string nome)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome é obrigatório");
        DomainExceptionValidation.When(nome.Length < 3, "Nome inválido");
        Nome = nome;
    }
}