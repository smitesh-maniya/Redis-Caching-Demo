using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Newtonsoft.Json;
using ODataRedisCaching.Models;
using StackExchange.Redis;
using System.Text;
//using System.Text.Json;

namespace ODataRedisCaching.Caching
{
    public class RedisOutputCacheStore : IOutputCacheStore
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisOutputCacheStore(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async ValueTask EvictByTagAsync(string tag, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(tag, "tag");
            var db = _connectionMultiplexer.GetDatabase();
            var cachedKeys = await db.SetMembersAsync(tag);
            var keys= cachedKeys
                .Select(x => (RedisKey)x.ToString())
                .Concat(new[] {(RedisKey)tag})
                .ToArray();
            await db.KeyDeleteAsync(keys);
        }

        public async ValueTask<byte[]?> GetAsync(string key, CancellationToken cancellationToken)
        {
            if (!key.ToLower().Contains("odata"))
                return null;
            ArgumentNullException.ThrowIfNull(key, "key");
            
            Console.WriteLine("Getting from cache "+key);
            var db = _connectionMultiplexer.GetDatabase();
            
            var val= await db.StringGetAsync(key);

            //byte[] object1 = (byte[]) val.Box();
            //var resStr = Encoding.UTF8.GetString(object1);
            
            //List<Student> students = new();
            //students = JsonSerializer.CreateDefault().Deserialize<List<Student>>(resStr);
            ////Console.WriteLine(object1);
            return val;
        }

        public async ValueTask SetAsync(string key, byte[] value, string[]? tags, TimeSpan validFor, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(key, "key");
            ArgumentNullException.ThrowIfNull(value, "value");

            var db = _connectionMultiplexer.GetDatabase();

            foreach(var tag in tags ?? Array.Empty<string>())
            {
                await db.SetAddAsync(tag, key);
            }
            await db.StringSetAsync(key, (RedisValue) value,validFor);
            
        }
    }
}
