using Ecommerce.Application.Baskets.Dtos;
using Ecommerce.Domain.Common;

namespace Ecommerce.Application.Baskets.Services;

public interface IBasketService
{
    Task<Result<BasketDto>> GetAsync(Guid basketId, CancellationToken ct = default);

    Task<Result<BasketDto>> CreateOrUpdateAsync(BasketDto basket, CancellationToken ct = default);

    Task<Result> DeleteAsync(Guid basketId, CancellationToken ct = default);
}
