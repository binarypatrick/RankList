using Microsoft.Extensions.DependencyInjection;
using RankList.Common.Interfaces;
using RankList.Common.Services;

namespace RankList.Common;

public static class CommonExtensions
{
    public static IServiceCollection AddCommonServices(this IServiceCollection services)
    {
        services.AddScoped<IToastManager, ToastManager>();
        return services;
    }
}