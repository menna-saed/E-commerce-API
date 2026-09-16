using Ecommerce.Domain.Common;
using Ecommerce.Domain.common;

namespace Ecommerce.Domain.Baskets;

public static class BasketErrors
{
    public static readonly Error NotFound = new(
        "Basket.NotFound",
        "The basket was not found.",
        ErrorType.NotFound);

    public static readonly Error InvalidId = new(
        "Basket.InvalidId",
        "The basket id is invalid.",
        ErrorType.Validation);

    public static readonly Error SaveFailed = new(
        "Basket.SaveFailed",
        "The basket could not be saved.",
        ErrorType.Conflict);
}
