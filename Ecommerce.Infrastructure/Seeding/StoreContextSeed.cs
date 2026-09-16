using Ecommerce.Infrastructure.DBcontext;
using ECommerce.Infrastructure.Identity;
using Ecommerce.Interface.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Infrastructure.Seeding;

public static class StoreContextSeed
{
    public static async Task SeedAsync(AppDBcontext dbContext,
        RoleManager<ApplicationRole> roleManager,
        UserManager<ApplicationUser> userManager,
        IConfiguration config
        )
    {
        if (!dbContext.ProductTypes.Any())
        {
            var data = ProducTypeSeed.ProductTypes;
            dbContext.ProductTypes.AddRange(data);
            dbContext.SaveChanges();

        }
        
        if (!dbContext.ProductBrands.Any())
        {
            var data = ProductBrandSeed.ProductBrands();
            dbContext.ProductBrands.AddRange(data);
            dbContext.SaveChanges();

        }
        
        var instance = new IdentitySeed(roleManager, userManager , config);
        await instance.SeedAsync();
            
        
    }
}