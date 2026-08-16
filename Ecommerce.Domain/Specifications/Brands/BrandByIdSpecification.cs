using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Specifications.Brands;

public sealed class BrandByIdSpecification : BaseSpecification<ProductBrand>
{
    public BrandByIdSpecification(Guid id)
    {
        Where(brand => brand.Id == id && !brand.IsDeleted);
        Include(brand => brand.Products);
    }
}
