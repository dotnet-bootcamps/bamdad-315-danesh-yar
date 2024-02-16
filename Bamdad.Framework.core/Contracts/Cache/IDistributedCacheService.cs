namespace Bamdad.Framework.core.Contracts.Cache;
public interface IDistributedCacheService
{
    Task Set<T>(string key, T value, TimeSpan timespan, CancellationToken cancellationToken);
    Task Set<T>(Dictionary<string, T> keyValueData, TimeSpan timespan, CancellationToken cancellationToken);
    Task<T?> Get<T>(string key, CancellationToken cancellationToken) where T : class;
    Task<List<T>?> Get<T>(IEnumerable<string> key, CancellationToken cancellationToken) where T : class;
    Task Remove(string key, CancellationToken cancellationToken);
}

