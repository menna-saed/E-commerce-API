namespace Ecommerce.Application.Brands.Dtos;

public interface IProductBrandQueryService
{
    Task<IReadOnlyList<BrandDto>> GetAllAsync (CancellationToken cancellationToken = default);

}