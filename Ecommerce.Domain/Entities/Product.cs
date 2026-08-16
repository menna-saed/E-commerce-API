using Ecommerce.Domain.Common;
using Ecommerce.Domain.Products;

namespace Ecommerce.Domain.Entities;

public class Product : BaseEntity
{
    private Product() { }

    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public decimal Price { get; private set; }
    public string ImageUrl { get; private set; } = null!;
    public bool IsActive { get; private set; } = true;

    public Guid ProductTypeId { get; private set; }
    public ProductType ProductType { get; private set; } = null!;

    public Guid ProductBrandId { get; private set; }
    public ProductBrand ProductBrand { get; private set; } = null!;

    public static Result<Product> Create(
        string name,
        string description,
        decimal price,
        string imageUrl,
        Guid productTypeId,
        Guid productBrandId)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result<Product>.Failure(ProductErrors.InvalidName);

        if (string.IsNullOrWhiteSpace(description))
            return Result<Product>.Failure(ProductErrors.InvalidDescription);

        if (string.IsNullOrWhiteSpace(imageUrl))
            return Result<Product>.Failure(ProductErrors.InvalidImageUrl);

        if (price <= 0)
            return Result<Product>.Failure(ProductErrors.InvalidPrice);

        if (productTypeId == Guid.Empty)
            return Result<Product>.Failure(ProductErrors.InvalidId);

        if (productBrandId == Guid.Empty)
            return Result<Product>.Failure(ProductErrors.InvalidId);

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name.Trim(),
            Description = description.Trim(),
            Price = price,
            ImageUrl = imageUrl.Trim(),
            ProductTypeId = productTypeId,
            ProductBrandId = productBrandId,
            IsActive = true
        };

        return Result<Product>.Success(product);
    }

    public Result UpdateDetails(string name, string description, string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure(ProductErrors.InvalidName);

        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure(ProductErrors.InvalidDescription);

        if (string.IsNullOrWhiteSpace(imageUrl))
            return Result.Failure(ProductErrors.InvalidImageUrl);

        Name = name.Trim();
        Description = description.Trim();
        ImageUrl = imageUrl.Trim();

        return Result.Success();
    }

    public Result ChangePrice(decimal newPrice)
    {
        if (newPrice <= 0)
            return Result.Failure(ProductErrors.InvalidPrice);

        Price = newPrice;

        return Result.Success();
    }

    public Result ChangeBrand(Guid newProductBrandId)
    {
        if (newProductBrandId == Guid.Empty)
            return Result.Failure(ProductErrors.InvalidId);

        ProductBrandId = newProductBrandId;

        return Result.Success();
    }

    public Result ChangeType(Guid newProductTypeId)
    {
        if (newProductTypeId == Guid.Empty)
            return Result.Failure(ProductErrors.InvalidId);

        ProductTypeId = newProductTypeId;

        return Result.Success();
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}