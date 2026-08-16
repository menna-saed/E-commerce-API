using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Specifications.Types;

public sealed class ActiveTypesSpecification : BaseSpecification<ProductType>
{
    public ActiveTypesSpecification()
    {
        Where(type => !type.IsDeleted);
    }
}
