using System.Text.Json;
using Ecommerce.Domain.Repository;
using StackExchange.Redis;

namespace Ecommerce.Infrastructure.Repsoitories;

public sealed class CacheRepository(IConnectionMultiplexer connection) : ICacheRepository
{
    private readonly IDatabase _database = connection.GetDatabase();

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default, TimeSpan? timeToLive = null)
    {
        var value = await _database.StringGetAsync(key);

        if (value.IsNullOrEmpty)
            return default;

        // TO json =>  object 
        return JsonSerializer.Deserialize<T>(((string)value)!);
    }

    public async Task<bool> SetAsync<T>(
        string key,
        T value,
        CancellationToken cancellationToken = default,
        TimeSpan? timeToLive = null)
    {
        // to JSON 
        var json = JsonSerializer.Serialize(value);
        return await _database.StringSetAsync(key, json, timeToLive ?? TimeSpan.FromDays(7));
    }

    public async Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default,TimeSpan? timeToLive = null)
    {
        return await _database.KeyDeleteAsync(key);
    }

    public async Task<bool> ExistsAsync(string key, CancellationToken cancellationToken = default , TimeSpan? timeToLive = null)
    {
        return await _database.KeyExistsAsync(key);
    }
}
