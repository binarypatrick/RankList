using Microsoft.Extensions.DependencyInjection;
using RankList.Data.Database;
using RankList.Data.Models;

namespace RankList.Data;

public static class DataExtensions
{
    public static void AddAppData(this IServiceCollection services, ConnectionOptions connectionOptions)
    {
        ArgumentNullException.ThrowIfNull(connectionOptions);
        connectionOptions.ValidateConnectionString();

        services.AddSingleton(connectionOptions);
        services.AddDbContext<AppDbContext>();
    }
}