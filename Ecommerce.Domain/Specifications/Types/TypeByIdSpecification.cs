using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Specifications.Types;

public sealed class TypeByIdSpecification : BaseSpecification<ProductType>
{
    public TypeByIdSpecification(Guid id)
    {
        Where(type => type.Id == id && !type.IsDeleted);
        Include(type => type.Products);
    }
}
