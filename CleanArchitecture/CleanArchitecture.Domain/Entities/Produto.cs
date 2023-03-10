using CleanArchitecture.Domain.Validations;

namespace CleanArchitecture.Domain.Entities;

public sealed class Produto : Entity
{
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }
    public string Imagem { get; private set; }

    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }

    public Produto(string nome, string descricao, decimal preco, int estoque, string imagem)
    {
        ValidarDominio(nome, descricao, preco, estoque, imagem);
    }

    public Produto(int id, string nome, string descricao, decimal preco, int estoque, string imagem)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido!");
        Id = id;
        ValidarDominio(nome, descricao, preco, estoque, imagem);
    }

    public void Atualizar(string nome, string descricao, decimal preco, int estoque, string imagem, int categoriaId)
    {
        ValidarDominio(nome, descricao, preco, estoque, imagem);
        CategoriaId = categoriaId;
    }

    private void ValidarDominio(string nome, string descricao, decimal preco, int estoque, string imagem)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido! Nome é obrigatório");

        DomainExceptionValidation.When(nome.Length < 3, "Nome inválido! É necessário pelo pelo menos 3 caracteres.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Descrição inválido! Descrição é obrigatória");

        DomainExceptionValidation.When(descricao.Length < 5, "Descrição inválido! É necessário pelo pelo menos 5 caracteres.");

        DomainExceptionValidation.When(preco < 0, "Preço inválido!");

        DomainExceptionValidation.When(estoque < 0, "Estoque Inválido!");

        DomainExceptionValidation.When(imagem.Length > 250, "Nome da Imagem Inválido! É permitido até 250 caracteres.");

        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Estoque = estoque;
        Imagem = imagem;
    }
}
