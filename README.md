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

# Deploy Poc On Docker:

Here We added docker file and docker compose file to run multiple container at a time.
- Here total 3 container will be created.
1. ms-sql-server
2. redis(cache)
3. odatarediscaching

Description:
- During creating container migration will be applyed so database will be created.
- There is volumn which we have used to store data. During creating container you will get blank database.
- Here we add docker secret for security purpose in docker-compose.yml file.
- Here we have created two secret one is for sql and other one for redis database password.

How to create Docker Secrets?
- To create Docker secret use below command:
- echo "SetPassword" | docker secret create NameOfSecret -
- For more Detail: https://blog.gitguardian.com/how-to-handle-secrets-in-docker/

As per your requirement you can create your secrets and use in docker-compose.yml file.

How to Deploy on docker?
1. Create secrets.
2. Use below command to create image:
    - docker compose up -d
    - Using this command containers will be created.
3. To remove container
    - docker compose down
