using Microsoft.Extensions.Caching.Distributed;

namespace Application.Services.Abstract;
public interface ICacheService
{
    Task<T> GetAsync<T>(string key);
    Task<T> GetOrSetAsync<T>(string key,string value);
}
