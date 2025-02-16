namespace RankList;

public static class Extensions
{
    public static T Bind<T>(this IConfiguration configuration) where T : new()
    {
        T obj = new();
        configuration.Bind(obj);
        return obj;
    }
}