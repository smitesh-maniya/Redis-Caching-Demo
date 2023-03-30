using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Caching.Distributed;

namespace ODataRedisCaching.Caching
{
    public class RedisOutputCacheStore : IOutputCacheStore
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<RedisOutputCacheStore> _logger;
        public RedisOutputCacheStore(IDistributedCache cache, ILogger<RedisOutputCacheStore> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public ValueTask EvictByTagAsync(string tag, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<byte[]?> GetAsync(string key, CancellationToken cancellationToken)
        {
            if (!key.ToLower().Contains("odata"))
                return null;
            ArgumentNullException.ThrowIfNull(key, "key");

            _logger.LogInformation("Getting from Cache");

            var val =await  _cache.GetAsync(key);
            return val;
        }

        public async ValueTask SetAsync(string key, byte[] value, string[]? tags, TimeSpan validFor, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(key, "key");
            ArgumentNullException.ThrowIfNull(value, "value");

            _logger.LogInformation("Adding in cache");

            var options = new DistributedCacheEntryOptions();
            options.SetAbsoluteExpiration(validFor);

            await _cache.SetAsync(key, value,options);
        }
    }
}
