using Application.Services.Abstract;
using Application.Services.Concrete;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<Credentials>(configuration.GetSection("Credentials"));
        services.AddTransient<ICacheService, CacheService>();
        services.AddTransient<ISoapService, SoapService>();
        services.AddTransient<IBusService, BusService>();

        return services;
    }
}
