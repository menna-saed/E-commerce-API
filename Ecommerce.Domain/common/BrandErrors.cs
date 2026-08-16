namespace Ecommerce.Domain.common;

public static class BrandErrors
{
    
    public static readonly Error InvalidName = new(
        "Product.InvalidName",
        "The product name is invalid.",
        ErrorType.Validation);  
    
    public static readonly Error InvalidId= new(
        "Product.InvalidDescription",
        "The product description is invalid.",
        ErrorType.Validation);
    
    
    
    public static readonly Error NotFound = new(
        "Brand.NotFound",
        "The brand was not found.",
        ErrorType.NotFound);
}