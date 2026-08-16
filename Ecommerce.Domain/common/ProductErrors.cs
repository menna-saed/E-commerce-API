using Ecommerce.Domain.common;

namespace Ecommerce.Domain.Products;

using Ecommerce.Domain.Common;

public static class ProductErrors
{
    public static readonly Error NotFound = new(
        "Product.NotFound",
        "The product was not found.",
        ErrorType.NotFound);

    public static readonly Error AlreadyExists = new(
        "Product.AlreadyExists",
        "A product with the same name already exists.",
        ErrorType.Conflict);

    public static readonly Error InvalidName = new(
        "Product.InvalidName",
        "The product name is invalid.",
        ErrorType.Validation);

    public static readonly Error InvalidDescription = new(
        "Product.InvalidDescription",
        "The product description is invalid.",
        ErrorType.Validation);
    
    public static readonly Error InvalidId= new(
        "Product.InvalidDescription",
        "The product description is invalid.",
        ErrorType.Validation);


    public static readonly Error InvalidPrice = new(
        "Product.InvalidPrice",
        "The product price must be greater than zero.",
        ErrorType.Validation);

    public static readonly Error InvalidImageUrl = new(
        "Product.InvalidImageUrl",
        "The product image URL is invalid.",
        ErrorType.Validation);

    public static readonly Error BrandNotFound = new(
        "Product.BrandNotFound",
        "The specified brand was not found.",
        ErrorType.NotFound);

    public static readonly Error CategoryNotFound = new(
        "Product.CategoryNotFound",
        "The specified category was not found.",
        ErrorType.NotFound);
}