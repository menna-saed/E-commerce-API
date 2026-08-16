using Ecommerce.Application.Brands.Dtos;
using Ecommerce.Application.Products.Dtos;
using Ecommerce.Application.Types.Dtos;
using Ecommerce.Infrastructure.Configration.DBcontext;
using Ecommerce.Interface.HealthChecks;
using Ecommerce.Interface.Presistence.Interceptors;
using Ecommerce.Interface.Presistence.Queries;
using Ecommerce.Interface.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<AuditableEntityInterceptor>();

        services.AddDbContext<AppDBcontext>((sp, options) =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));

            options.AddInterceptors(
                sp.GetRequiredService<AuditableEntityInterceptor>());
        });
        
        services.AddScoped<IProdcutQueryService, ProductQueryService>();
        services.AddScoped<IProductBrandQueryService, ProductBrandQueryService>();
        services.AddScoped<IProductTypeQueryService, ProductTypeQueryService>();
        
        services
            .AddHealthChecks()
            .AddDbContextCheck<AppDBcontext>()
            .AddCheck<TestHealthCheck>("test");
        return services;
    }
    
    public static async Task SeedDatabaseAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<AppDBcontext>();

        await StoreContextSeed.SeedAsync(context);
    }
    
   
}