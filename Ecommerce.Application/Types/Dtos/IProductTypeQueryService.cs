namespace Ecommerce.Application.Types.Dtos;

public interface IProductTypeQueryService
{
    Task<IReadOnlyList<TypeDto>> GetAllAsync(CancellationToken cancellationToken = default);
}