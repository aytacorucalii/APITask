using Final.Core.Entities;
using Final.DAL.Repositories.Abstractions;
using Final.DAL.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Final.DAL.DataConfigurations.Repo;

public static class RepositoryConfiguration 
{
    public static void AddRepositoryConfigration(this IServiceCollection Service)
    {
        Service.AddScoped<IProductRepository, ProductRepository>();
        Service.AddScoped<ICategoryRepository, CategoryRepository>();
        Service.AddScoped<IColorRepository, ColorRepository>();
        Service.AddScoped<ISizeRepository, SizeRepository>();
        Service.AddScoped<IGenericRepository<ProductColor>,GenericRepository<ProductColor>>();
        Service.AddScoped<IGenericRepository<ProductSize>, GenericRepository<ProductSize>>();
    }
}
