using Ecommerce.Application.Products.Dtos;
using Ecommerce.Domain.common;
using Ecommerce.Domain.Common;

namespace Ecommerce.Application.Products.Queries;

public sealed class GetAllProdcutQuery(IProdcutQueryService  productQueryService)
{
  
        public async Task<Result<IReadOnlyList<ProductDto>>> ExecuteAsync(
          ProductQueryParameters parameters,
            CancellationToken cancellationToken = default)
        { 
            var products = await productQueryService.GetAllAsync(parameters, cancellationToken);
            return Result<IReadOnlyList<ProductDto>>.Success(products);
        }
    
} 