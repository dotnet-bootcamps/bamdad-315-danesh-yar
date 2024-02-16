namespace Bamdad.Framework.core.Contracts.Cache;
public interface IMemoryCacheService
{
    void Set<T>(string key, T value, TimeSpan timespan);
    T? Get<T>(string key) where T : class;
    void Remove(string key);
}
