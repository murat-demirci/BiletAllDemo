using Application.Services.Abstract;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using Newtonsoft.Json;

namespace Application.Services.Concrete;
public sealed class CacheService(IDistributedCache cache) : ICacheService
{
    public async Task<T> GetAsync<T>(string key)
    {
        byte[]? cachedResponse = await cache.GetAsync(key);
       return cachedResponse is null ? default :  JsonConvert.DeserializeObject<T>(Encoding.Default.GetString(cachedResponse));
    }

    public async Task<T> GetOrSetAsync<T>(string key, string value)
    {
        T response = default;
        byte[]? cachedResponse = await cache.GetAsync(key);
        if (cachedResponse != null)
        {
            response = JsonConvert.DeserializeObject<T>(Encoding.Default.GetString(cachedResponse));
        }
        else
        {
            DistributedCacheEntryOptions cacheOptions = new() { SlidingExpiration = TimeSpan.FromHours(3) };
            byte[] serializeData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value));
            await cache.SetAsync(key, serializeData, cacheOptions);
        }

        return response;
    }
}
