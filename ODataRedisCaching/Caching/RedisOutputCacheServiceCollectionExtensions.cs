using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ODataRedisCaching.Caching
{
    //custom implementation for AddRedisOutputCache service with/without configurationOptions
    public static class RedisOutputCacheServiceCollectionExtensions
    {
        public static IServiceCollection AddRedisOutputCache(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);
            
            services.AddOutputCache();  //adding dedault in-memory output cache

            services.RemoveAll<IOutputCacheStore>(); //remove in-memory storage

            //adding custom redisoutputcache store implementation
            services.TryAddSingleton<IOutputCacheStore,RedisOutputCacheStore>(); 
            return services;
        }

        public static IServiceCollection AddRedisOutputCache(this IServiceCollection services, Action<OutputCacheOptions> configureOptions)
        {
            ArgumentNullException.ThrowIfNull(services);
            ArgumentNullException.ThrowIfNull(configureOptions);
            
            //configure options
            services.Configure(configureOptions);
            
            services.AddRedisOutputCache();
            return services;
        }

    }
}
