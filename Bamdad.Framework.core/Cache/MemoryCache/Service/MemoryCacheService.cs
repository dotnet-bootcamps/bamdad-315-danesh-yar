using Bamdad.Framework.core.Contracts.Cache;
using Microsoft.Extensions.Caching.Memory;
namespace Bamdad.Framework.core.Cache.MemoryCache.Service;
public class MemoryCacheService : IMemoryCacheService
{
    private readonly IMemoryCache _memoryCache;


    public MemoryCacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    public void Set<T>(string key, T value, TimeSpan timespan)
    {
        _memoryCache.Set(key, value, timespan);
    }

    public T? Get<T>(string key) where T : class
    {
        return _memoryCache.Get<T?>(key);
    }

    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }
}
