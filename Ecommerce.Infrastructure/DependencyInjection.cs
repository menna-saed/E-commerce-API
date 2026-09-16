using Ecommerce.Application.Brands.Dtos;
using Ecommerce.Application.Products.Dtos;
using Ecommerce.Application.Types.Dtos;
using Ecommerce.Application.Identity.Services;
using Ecommerce.Domain.Repository;
using Ecommerce.Infrastructure.DBcontext;
using Ecommerce.Infrastructure.Identity;
using ECommerce.Infrastructure.Identity;
using Ecommerce.Infrastructure.Persistence.Queries;
using Ecommerce.Infrastructure.Repsoitories;
using Ecommerce.Infrastructure.Seeding;
using Ecommerce.Interface.HealthChecks;
using Ecommerce.Interface.Presistence.Interceptors;
using Ecommerce.Interface.Presistence.Queries;
using Ecommerce.Interface.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Ecommerce.Infrastructure;

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
                configuration.GetConnectionString("DefaultConnection"),sql => sql.MigrationsHistoryTable("__EFMigrationsHistory", "Identity"));

            options.AddInterceptors(
                sp.GetRequiredService<AuditableEntityInterceptor>());
        });
        services.AddDbContext<AppIdentityDbContext>((sp, options) =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));

        });
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IIdentityService, IdentityService>();
        
        
        services.AddScoped<IProdcutQueryService, ProductQueryService>();
        services.AddScoped<IProductBrandQueryService, ProductBrandQueryService>();
        services.AddScoped<IProductTypeQueryService, ProductTypeQueryService>();
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped<ICacheRepository, CacheRepository>();
        
        services.AddSingleton<IConnectionMultiplexer>(config =>
        {
            return ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection"));
        });
        
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
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
        var  userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

        await StoreContextSeed .SeedAsync(context,roleManager,userManager,config);
    }
    
    
    
   
}
