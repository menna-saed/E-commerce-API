using Ecommerce.Domain.Common;
using Ecommerce.Domain.common;

namespace Ecommerce.Domain.Caching;

public static class CacheErrors
{
    public static readonly Error NotFound = new(
        "Cache.NotFound",
        "The cache entry was not found.",
        ErrorType.NotFound);

    public static readonly Error InvalidKey = new(
        "Cache.InvalidKey",
        "The cache key is invalid.",
        ErrorType.Validation);

    public static readonly Error SaveFailed = new(
        "Cache.SaveFailed",
        "The cache entry could not be saved.",
        ErrorType.Conflict);
}
