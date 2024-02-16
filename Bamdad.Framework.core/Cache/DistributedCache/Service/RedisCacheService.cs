using Bamdad.Framework.core.Contracts.Cache;
using EasyCaching.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamdad.Framework.core.Cache.DistributedCache.Service;
public class RedisCacheService : IDistributedCacheService
{
    private readonly IEasyCachingProvider _provider;

    public RedisCacheService(IEasyCachingProvider provider)
    {
        _provider = provider;
    }
    public async Task Set<T>(string key, T value, TimeSpan timespan, CancellationToken cancellationToken)
    {
        await _provider.SetAsync(key, value, timespan, cancellationToken);
    }

    public async Task Set<T>(Dictionary<string, T> keyValueData, TimeSpan timespan, CancellationToken cancellationToken)
    {
        await _provider.SetAllAsync(keyValueData, timespan, cancellationToken);
    }

    public async Task<T?> Get<T>(string key, CancellationToken cancellationToken) where T : class
    {
        var cacheObj = await _provider.GetAsync<T>(key, cancellationToken);
        return !cacheObj.IsNull ? cacheObj.Value : null;
    }

    public async Task<List<T>?> Get<T>(IEnumerable<string> key, CancellationToken cancellationToken) where T : class
    {
        var cacheObj = await _provider.GetAllAsync<T>(key, cancellationToken);

        return cacheObj.Values.Count > 0 ? cacheObj.Values.Where(x => x.HasValue).Select(x => x.Value).ToList() : null;
    }

    public async Task Remove(string key, CancellationToken cancellationToken)
    {
        await _provider.RemoveAsync(key, cancellationToken);
    }
}