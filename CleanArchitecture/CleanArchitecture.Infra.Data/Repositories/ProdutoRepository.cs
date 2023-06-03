using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infra.Data.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ApplicationDbContext _context;

    public ProdutoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Produto>> ObterProdutosAsync()
    {
        return await _context.Produtos.AsNoTracking().ToListAsync();
    }

    public async Task<Produto> ObterProdutoPorIdAsync(int? id)
    {
        return await _context.Produtos.Include(c => c.Categoria).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Produto> AdicionarAsync(Produto produto)
    {
        _context.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> AtualizarAsync(Produto produto)
    {
        _context.Update(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> ExcluirAsync(Produto produto)
    {
        _context.Remove(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}