using Ecommerce.BL.Services.Abstractions;
using Ecommerce.BL.Services.Impementation;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.BL.Configurations;

public static class ServiceConfiguration
{
    public static void AddBusinessConfiguration( this IServiceCollection Service)
    {
        Service.AddScoped<IProductService, ProductService>();
        Service.AddScoped<IOrderItemService , OrderItemService>();
        Service.AddScoped<IOrderService , OrderService>();

    }
}
