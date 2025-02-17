using Microsoft.Extensions.DependencyInjection;
using RankList.Services.Abstractions;
using RankList.Services.Services;

namespace RankList.Services;

public static class ServiceExtensions
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
    }
}