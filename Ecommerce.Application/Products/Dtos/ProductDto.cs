namespace Ecommerce.Application.Products.Dtos;

public sealed record ProductDto(

         Guid Id,
        string Name,
        string Description,
        string PictureUrl,
        decimal Price,
        string ProductBrand,
         string ProductType
    );
