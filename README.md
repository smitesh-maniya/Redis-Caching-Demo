# Redis-Caching-Demo

We have build one PoC to Cache OData API responses. To store cache data we are using Redis Database.

Packages which are used here:
- Microsoft.AspNetCore.OData
- Microsoft.Extensions.Caching.StackExchangeRedis
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer

Services used:
- AddStackExchangeRedisCache (Microsoft.Extensions.Caching.StackExchangeRedis)
- AddRedisOutputCache (Custom)

Middleware used:
- UseOutputCache()

Description:
- Here we add service AddStackExchangeRedisCache which is used to make connection with Redis Database and inject the IDistributedCache dependency for RedisCache implementation.
- In custom AddRedisOutputCache service, we added AddOutputCache service and remove IOutputCacheStore dependency which is in-memory cache store implementation. Then added IOutputCacheStore dependency with our custom RedisOutputCacheStore implementation.
