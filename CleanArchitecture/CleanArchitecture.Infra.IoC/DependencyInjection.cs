using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddAutoMapper(typeof(DomainToDTOMapping));

        return services;
    }
}