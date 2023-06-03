using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Validations;
using FluentAssertions;

namespace CleanArchitecture.Domain.Tests;

public class CategoriaTest
{
    [Fact(DisplayName = "Criar Categoria com parâmetros válidos")]
    public void CriarCategoria_ComParametroValidos_RetornaObjetoComEstadoValido()
    {
        Action action = () => new Categoria(1, "Categoria Teste");
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Criar Categoria com Id inválido")]
    public void CriarCategoria_ComIdInvalido_RetornaObjetoComEstadoInvalido()
    {
        Action action = () => new Categoria(-1, "Categoria Teste");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Id inválido");
    }

    [Fact(DisplayName = "Criar Categoria com Nome inválido")]
    public void CriarCategoria_ComNomeInvalido_RetornaObjetoComEstadoInvalido()
    {
        Action action = () => new Categoria(1, "Ca");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Nome inválido");
    }

    [Fact(DisplayName = "Criar Categoria com Nome nulo")]
    public void CriarCategoria_ComNomeNulo_RetornaObjetoComEstadoInvalido()
    {
        Action action = () => new Categoria(1, null);
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Nome é obrigatório");
    }

    [Fact(DisplayName = "Criar Categoria com Nome vazio")]
    public void CriarCategoria_ComNomeVazio_RetornaObjetoComEstadoInvalido()
    {
        Action action = () => new Categoria(1, string.Empty);
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Nome é obrigatório");
    }
}