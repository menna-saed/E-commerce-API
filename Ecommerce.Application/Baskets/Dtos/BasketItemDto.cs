namespace Ecommerce.Application.Baskets.Dtos;

public sealed record BasketItemDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int Quantity);
