namespace Ecommerce.Application.Baskets.Dtos;

public sealed record BasketDto(
    Guid Id,
    IReadOnlyList<BasketItemDto> Items);
