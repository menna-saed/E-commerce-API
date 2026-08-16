using Ecommerce.Infrastructure.Configration.DBcontext;

namespace Ecommerce.Interface.Seeding;

public static class StoreContextSeed
{
    public static async Task SeedAsync(AppDBcontext dbContext)
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
    }
}