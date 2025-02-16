using Microsoft.Extensions.DependencyInjection;
using RankList.Data.DbContexts;
using RankList.Data.Models;

namespace RankList.Data;

public static class DataExtensions
{
    public static IServiceCollection AddDataConfiguration(this IServiceCollection services, ConnectionOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        options.ValidateConnectionString();
        
        services.AddSingleton(options);
        services.AddDbContext<AppDbContext>();
        return services;
    }
}
