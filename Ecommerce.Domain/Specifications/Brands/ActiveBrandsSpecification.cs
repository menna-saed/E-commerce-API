using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Specifications.Brands;

public sealed class ActiveBrandsSpecification : BaseSpecification<ProductBrand>
{
    public ActiveBrandsSpecification()
    {
        Where(brand => !brand.IsDeleted);
    }
}
