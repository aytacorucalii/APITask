using Final.BL.ExternalServices.Abstractions;
using Final.BL.ExternalServices.Impementations;
using Final.BL.Services.Abstractions;
using Final.BL.Services.Implementations;
using Final.DAL.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Final.BL.Configurations;

public static class ServiceConfigurations
{
    public static void AddBusinessService(this IServiceCollection Services)
    {
        Services.AddScoped<IProductService, ProductService>();
        Services.AddScoped<IColorService, ColorService>();
        Services.AddScoped<ICategoryService, CategoryService>();
        Services.AddScoped<ISizeService, SizeService>();
        Services.AddScoped<IProductColorService, ProductColorService>();
        Services.AddScoped<IProductSizeService, ProductSizeService>();
        Services.AddScoped<IAuthService, AuthService>();
        Services.AddScoped<IJwtTokenService, JwtTokenService>();
       
    }
}
