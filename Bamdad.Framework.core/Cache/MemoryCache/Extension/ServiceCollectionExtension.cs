using Bamdad.Framework.core.Cache.MemoryCache.Service;
using Bamdad.Framework.core.Contracts.Cache;
using Microsoft.Extensions.DependencyInjection;

namespace Bamdad.Framework.core.Cache.MemoryCache.Extension;
public static class ServiceCollectionExtension
{
    public static void Add_InMemoryCache(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddScoped<IMemoryCacheService, MemoryCacheService>();
    }
}
