using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Seeding;

public static class ProductBrandSeed
{
    public static IReadOnlyList<ProductBrand> ProductBrands() =>
    [
        ProductBrand.CreateForSeed(Guid.Parse("a1b2c3d4-0001-0001-0001-000000000001"), "Nike"),
        ProductBrand.CreateForSeed(Guid.Parse("a1b2c3d4-0002-0002-0002-000000000002"), "Adidas"),
        ProductBrand.CreateForSeed(Guid.Parse("a1b2c3d4-0003-0003-0003-000000000003"), "Puma"),
    ];
}