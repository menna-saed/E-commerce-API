using Ecommerce.Domain.common;
using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public class ProductBrand : BaseEntity
{
    
    public static ProductBrand CreateForSeed(Guid id, string name)
    {
        return new ProductBrand
        {
            Id = id,
            Name = name
        };
    }
    public string Name { get; private set; } = null!;

    public ICollection<Product> Products { get; private set; } = [];

    public static Result Create(Guid id, string name)
    {
       
        if (string.IsNullOrWhiteSpace(name))
            return Result<ProductBrand>.Failure(BrandErrors.InvalidName);

        if (id == Guid.Empty)
            return Result<ProductBrand>.Failure(BrandErrors.InvalidId);

       var Brand =  new ProductBrand()
        {
            Id = id,
            Name = name
        };
       
       return Result<ProductBrand>.Success(Brand);
    }
}