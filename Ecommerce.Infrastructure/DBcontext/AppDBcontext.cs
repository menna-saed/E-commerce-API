using Ecommerce.Domain.Entities;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.DBcontext;

public class AppDBcontext : DbContext
{
    public AppDBcontext(DbContextOptions<AppDBcontext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductType> ProductTypes => Set<ProductType>();
    public DbSet<ProductBrand> ProductBrands => Set<ProductBrand>();
    public DbSet<UserAddress> UserAddresses => Set<UserAddress>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBcontext).Assembly, 
            type => type.Namespace == "Ecommerce.Infrastructure.DBcontext");
            ;
    }
}