using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Validations;
using FluentAssertions;

namespace CleanArchitecture.Domain.Tests;

public class ProdutoTest
{
    [Fact(DisplayName = "Criar Produto com parâmetros válidos")]
    public void CriarProduto_ComParametrosValidos_RetornaProduto()
    {
        Action action = () => new Produto("Produto Teste", "Descrição Teste", 9.99m, 10, "caminho/imagem.jpg");
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Criar Produto com id inválido")]
    public void CriarProduto_ComIdInvalido_RetornaDomainExceptionValidation()
    {
        Action action = () => new Produto(-1, "Produto Teste", "Descrição Teste", 9.99m, 10, "caminho/imagem.jpg");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Id inválido");
    }

    [Fact(DisplayName = "Criar Produto com nome inválido")]
    public void CriarProduto_ComNomeInvalido_RetornaDomainExceptionValidation()
    {
        Action action = () => new Produto("Pr", "Descrição Teste", 9.99m, 10, "caminho/imagem.jpg");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Nome muito curto, mínimo 3 caracteres");
    }

    [Fact(DisplayName = "Criar Produto com descrição inválida")]
    public void CriarProduto_ComDescricaoInvalida_RetornaDomainExceptionValidation()
    {
        Action action = () => new Produto("Produto Teste", "Desc", 9.99m, 10, "caminho/imagem.jpg");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Descrição muito curta, mínimo 5 caracteres");
    }

    [Fact(DisplayName = "Criar Produto com preço inválido")]
    public void CriarProduto_ComPrecoInvalido_RetornaDomainExceptionValidation()
    {
        Action action = () => new Produto("Produto Teste", "Descrição Teste", -1, 10, "caminho/imagem.jpg");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Preço inválido");
    }

    [Fact(DisplayName = "Criar Produto com estoque inválido")]
    public void CriarProduto_ComEstoqueInvalido_RetornaDomainExceptionValidation()
    {
        Action action = () => new Produto("Produto Teste", "Descrição Teste", 9.99m, -1, "caminho/imagem.jpg");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Estoque inválido");
    }

    [Fact(DisplayName = "Criar Produto com caminho muito grande")]
    public void CriarProduto_ComCaminhoMuitoGrande_RetornaDomainExceptionValidation()
    {
        Action action = () => new Produto("Produto Teste", "Descrição Teste", 9.99m, 10, "caminho/imagem.jpg".PadRight(251, 'a'));
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Caminho da imagem muito grande, máximo 250 caracteres");
    }
}