using Ecommerce.DAL.Repositories.Abstractions;
using Ecommerce.DAL.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.DAL.Configurations;

public static class RepositoryConfiguration
{
    public static void AddDataConfiguration(this IServiceCollection Service)
    {
        Service.AddScoped<IProductRepository, ProductRepository>();
        Service.AddScoped<IOrderItemRepository, OrderItemRepository>();
        Service.AddScoped<IOrderRepository, OrderRepository>();

    }
}
