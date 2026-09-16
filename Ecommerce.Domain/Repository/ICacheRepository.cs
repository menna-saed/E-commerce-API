namespace Ecommerce.Domain.Repository;

public interface ICacheRepository
{
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default , TimeSpan? timeToLive = null);

    Task<bool> SetAsync<T>(
        string key,
        T value,
        CancellationToken cancellationToken = default,
        TimeSpan? timeToLive = null);

    Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default, TimeSpan? timeToLive = null);

    Task<bool> ExistsAsync(string key, CancellationToken cancellationToken = default,TimeSpan? timeToLive = null);
}
