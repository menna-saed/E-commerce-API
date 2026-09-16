using Ecommerce.Application.Baskets.Dtos;
using Ecommerce.Domain.Entities.Basket;
using Ecommerce.Domain.Repository;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Baskets;
using MapsterMapper;

namespace Ecommerce.Application.Baskets.Services;

public sealed class BasketService(IBasketRepository basketRepository, IMapper mapper) : IBasketService
{
    public async Task<Result<BasketDto>> GetAsync(Guid basketId, CancellationToken ct = default)
    {
        if (basketId == Guid.Empty)
            return Result<BasketDto>.Failure(BasketErrors.InvalidId);

        var basket = await basketRepository.GetBasketAsync(basketId, ct);
        return basket is null
            ? Result<BasketDto>.Failure(BasketErrors.NotFound)
            : Result<BasketDto>.Success(mapper.Map<BasketDto>(basket));
    }

    public async Task<Result<BasketDto>> CreateOrUpdateAsync(BasketDto basketDto, CancellationToken ct = default)
    {
        if (basketDto.Id == Guid.Empty)
            return Result<BasketDto>.Failure(BasketErrors.InvalidId);

        var basket = mapper.Map<CustomerBasket>(basketDto);

        var savedBasket = await basketRepository.CreateOrUpdateBasketAsync (basket, ct);
        return savedBasket is null
            ? Result<BasketDto>.Failure(BasketErrors.SaveFailed)
            : Result<BasketDto>.Success(mapper.Map<BasketDto>(savedBasket));
    }

    public async Task<Result> DeleteAsync(Guid basketId, CancellationToken ct = default)
    {
        if (basketId == Guid.Empty)
            return Result.Failure(BasketErrors.InvalidId);

        var wasDeleted = await basketRepository.DeleteBasketAsync(basketId, ct);
        return wasDeleted
            ? Result.Success()
            : Result.Failure(BasketErrors.NotFound);
    }

}
