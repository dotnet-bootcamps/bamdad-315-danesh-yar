using Bamdad.Framework.core.Cache.DistributedCache.Service;
using Bamdad.Framework.core.Contracts.Cache;
using Bamdad.Framework.core.DTOs;
using EasyCaching.Core.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamdad.Framework.core.Cache.DistributedCache.Extension;
public static class ServiceCollectionExtension
{
    public static void Add_RedisDistributedCache(this IServiceCollection services, RedisConnectionDto connection)
    {
        services.AddScoped<IDistributedCacheService, RedisCacheService>();

        services.AddLZ4Compressor("LZ4");

        services.AddEasyCaching(option =>
        {
            option.UseRedis(config =>
            {
                config.DBConfig.Endpoints.Add(new ServerEndPoint(connection.Endpoints.Host, connection.Endpoints.Port));
                config.DBConfig.Database = connection.Database;
                config.DBConfig.Password = connection.Password;
                config.DBConfig.ConnectionTimeout = 60000;
                config.DBConfig.AsyncTimeout = 60000;
                config.DBConfig.SyncTimeout = 60000;
                config.SerializerName = "msgpack";
            })
                .WithMessagePack("msgpack")
                .WithCompressor("msgpack", "LZ4");
        });
    }
}