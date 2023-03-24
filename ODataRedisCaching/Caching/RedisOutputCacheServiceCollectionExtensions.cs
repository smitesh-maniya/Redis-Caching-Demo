using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.Options;

namespace ODataRedisCaching.Caching
{
    public static class RedisOutputCacheServiceCollectionExtensions
    {
        public static IServiceCollection AddRedisOutputCache(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services, "services");
            services.AddOutputCache();
            services.RemoveAll<IOutputCacheStore>();

            services.RemoveAll<Func<IServiceProvider, IOutputCacheStore>> ();
            services.AddSingleton<IOutputCacheStore,RedisOutputCacheStore>();
            return services;
        }

        public static IServiceCollection AddRedisOutputCache(this IServiceCollection services, Action<OutputCacheOptions> configureOptions)
        {
            ArgumentNullException.ThrowIfNull(services, "services");
            ArgumentNullException.ThrowIfNull(configureOptions, "configureOptions");
            services.Configure(configureOptions);
            services.AddOutputCache();

            services.RemoveAll<IOutputCacheStore>();
            services.RemoveAll<Func<IServiceProvider, IOutputCacheStore>>();
            services.AddSingleton<IOutputCacheStore, RedisOutputCacheStore>();
            return services;
        }
    }
}
