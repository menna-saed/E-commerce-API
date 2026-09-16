using Ecommerce.Domain.Common;

namespace Ecommerce.Application.Caching.Services;

public interface ICacheService
{
    Task<Result<TValue>> GetAsync<TValue>(string key, CancellationToken ct = default);

    Task<Result> SetAsync<TValue>(
        string key,
        TValue value,
        CancellationToken ct = default,
        TimeSpan? timeToLive = null);

    Task<Result> RemoveAsync(string key, CancellationToken ct = default);
}
