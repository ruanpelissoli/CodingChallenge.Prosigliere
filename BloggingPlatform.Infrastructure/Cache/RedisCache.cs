using BloggingPlatform.Domain.Abstractions;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace BloggingPlatform.Infrastructure.Cache;
internal class RedisCache : ICacheLayer
{
    private readonly IDistributedCache _cache;
    private readonly DistributedCacheEntryOptions _options;

    public RedisCache(IDistributedCache cache)
    {
        _cache = cache;
        _options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(2))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
    }

    public async Task<T?> Get<T>(string key, CancellationToken cancellationToken = default)
    {
        var json = await _cache.GetStringAsync(key, cancellationToken);

        if (json is not null)
        {
            return JsonConvert.DeserializeObject<T>(json)!;
        }

        return default;
    }

    public async Task Remove(string key, CancellationToken cancellationToken = default)
    {
        await _cache.RemoveAsync(key, cancellationToken);
    }

    public async Task Set<T>(string key, T item, CancellationToken cancellationToken = default)
    {
        var json = JsonConvert.SerializeObject(item);
        await _cache.SetStringAsync(key, json, _options, cancellationToken);
    }
}
