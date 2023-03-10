using CleanArchitecture.Domain.Validations;

namespace CleanArchitecture.Domain.Entities;

public sealed class Categoria : Entity
{
    public Categoria(string nome)
    {
        ValidarDominio(nome);
    }

    public Categoria(int id, string nome)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido!");
        Id = id;
        ValidarDominio(nome);
    }

    public string Nome { get; private set; }

    public ICollection<Produto> Produtos { get; private set; }

    public void Atualizar(string nome)
    {
        ValidarDominio(nome);
    }

    private void ValidarDominio(string nome)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido! Nome é obrigatório.");
        DomainExceptionValidation.When(nome.Length < 3, "Nome inválido! É necessário pelo pelo menos 3 caracteres.");

        Nome = nome;
    }
}
