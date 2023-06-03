using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infra.Data.Migrations
{
    public partial class SeedProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, Estoque, Imagem, CategoriaId) VALUES('Caderno', 'Caderno espiral 100 folhas', 7.45, 50, 'caderno.jpg', 1)");
            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, Estoque, Imagem, CategoriaId) VALUES('Estojo', 'Estojo escolar cinza', 5.98, 120, 'estojo.jpg', 1)");
            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, Estoque, Imagem, CategoriaId) VALUES('Borracha', 'Borracha branca pequena', 3.75, 80, 'borracha.jpg', 1)");
            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, Estoque, Imagem, CategoriaId) VALUES('Apontador', 'Apontador com depósito', 2.99, 130, 'apontador.jpg', 1)");
            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, Estoque, Imagem, CategoriaId) VALUES('Caneta', 'Caneta esferográfica azul', 1.99, 150, 'caneta.jpg', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
