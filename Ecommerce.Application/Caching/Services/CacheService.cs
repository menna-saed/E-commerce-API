using Ecommerce.Domain.Caching;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Repository;

namespace Ecommerce.Application.Caching.Services;

public sealed class CacheService(ICacheRepository cacheRepository) : ICacheService
{
    public async Task<Result<TValue>> GetAsync<TValue>(string key, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(key))
            return Result<TValue>.Failure(CacheErrors.InvalidKey);

        var value = await cacheRepository.GetAsync<TValue>(key, ct);
        return value is null
            ? Result<TValue>.Failure(CacheErrors.NotFound)
            : Result<TValue>.Success(value);
    }

    public async Task<Result> SetAsync<TValue>(
        string key,
        TValue value,
        CancellationToken ct = default,
        TimeSpan? timeToLive = null)
    {
        if (string.IsNullOrWhiteSpace(key))
            return Result.Failure(CacheErrors.InvalidKey);

        var saved = await cacheRepository.SetAsync(key, value, ct, timeToLive);
        return saved
            ? Result.Success()
            : Result.Failure(CacheErrors.SaveFailed);
    }

    public async Task<Result> RemoveAsync(string key, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(key))
            return Result.Failure(CacheErrors.InvalidKey);

        var removed = await cacheRepository.RemoveAsync(key, ct);
        return removed
            ? Result.Success()
            : Result.Failure(CacheErrors.NotFound);
    }
}
