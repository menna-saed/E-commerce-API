using Ecommerce.Domain.Entities;

namespace Ecommerce.Interface.Seeding;

public  static class ProducTypeSeed
{

    public static IReadOnlyList<ProductType> ProductTypes =>
    [

        ProductType.Create(Guid.Parse("b1c2d3e4-0001-0001-0001-000000000001"), "Boots"),
        ProductType.Create(Guid.Parse("b1c2d3e4-0002-0002-0002-000000000002"), "Gloves"),
        ProductType.Create(Guid.Parse("b1c2d3e4-0003-0003-0003-000000000003"), "Shirts"),
    ];


}