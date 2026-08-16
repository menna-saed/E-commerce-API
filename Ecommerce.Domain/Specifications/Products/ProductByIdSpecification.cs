using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Specifications.Products;

public sealed class ProductByIdSpecification : BaseSpecification<Product>
{
    public ProductByIdSpecification(Guid id)
    {
        Where(product => product.Id == id && !product.IsDeleted);
        Include(product => product.ProductBrand);
        Include(product => product.ProductType);
    }
}
