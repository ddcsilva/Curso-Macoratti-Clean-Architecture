using CleanArchitecture.Domain.Validations;

namespace CleanArchitecture.Domain.Entities;

public sealed class Produto : BaseEntity
{
    public Produto(string nome, string descricao, decimal preco, int estoque, string imagem)
    {
        Validar(nome, descricao, preco, estoque, imagem);
    }

    public Produto(int id, string nome, string descricao, decimal preco, int estoque, string imagem)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido");
        Validar(nome, descricao, preco, estoque, imagem);
        Id = id;
    }

    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }
    public string Imagem { get; private set; }

    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }

    public void Atualizar(string nome, string descricao, decimal preco, int estoque, string imagem, int categoriaId)
    {
        Validar(nome, descricao, preco, estoque, imagem);
        CategoriaId = categoriaId;
    }

    private void Validar(string nome, string descricao, decimal preco, int estoque, string imagem)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome é obrigatório");
        DomainExceptionValidation.When(nome.Length < 3, "Nome muito curto, mínimo 3 caracteres");
        DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Descrição é obrigatória");
        DomainExceptionValidation.When(descricao.Length < 5, "Descrição muito curta, mínimo 5 caracteres");
        DomainExceptionValidation.When(preco < 0, "Preço inválido");
        DomainExceptionValidation.When(estoque < 0, "Estoque inválido");
        DomainExceptionValidation.When(imagem?.Length > 250, "Caminho da imagem muito grande, máximo 250 caracteres");
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Estoque = estoque;
        Imagem = imagem;
    }
}