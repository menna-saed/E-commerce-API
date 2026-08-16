using Ecommerce.Domain.common;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Specifications.Products;

public sealed class ActiveProductsSpecification : BaseSpecification<Product>
{
    public ActiveProductsSpecification(ProductQueryParameters parameters)
    {
        if (parameters.brandId == Guid.Empty)
            parameters.brandId = null;

        if (parameters.typeId == Guid.Empty)
            parameters. typeId = null;
        

        Where(product =>
            product.IsActive &&
            !product.IsDeleted &&
            (parameters.brandId == null || product.ProductBrandId ==parameters.brandId) &&
            (parameters.typeId == null || product.ProductTypeId == parameters.typeId))  
            
            ;

        Include(product => product.ProductBrand);
        Include(product => product.ProductType);

        switch (parameters.OrderBy)
        {
            case common.OrderBy.NameAsc :
                orderBy(p => p.Name);
                break;
            
         case common.OrderBy.NameDesc :
                orderByDesc(p => p.Name);
                break;
         
         case common.OrderBy.PriceAsc :
                orderBy(p => p.Price);
                break;
         case common.OrderBy.PriceDesc :
                orderByDesc(p => p.Price);
             break;
         
         default:
             orderBy(p =>p.Id);
             break;
        }


       ApplyPagintaed(parameters.PageNumber , parameters.PageSize);
       

        
    }
}
