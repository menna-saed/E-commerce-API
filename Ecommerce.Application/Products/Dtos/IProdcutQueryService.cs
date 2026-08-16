using Ecommerce.Domain.common;

namespace Ecommerce.Application.Products.Dtos;

public interface IProdcutQueryService
{
    Task<IReadOnlyList<ProductDto>> GetAllAsync(ProductQueryParameters parameters, CancellationToken ct = default);
    
    Task<ProductDto?> GetById (Guid id , CancellationToken ct = default );
}