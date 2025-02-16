namespace RankList.Data.Models;

public class ConnectionOptions
{
    public string? Host { get; init; }
    public string? Database { get; init; }
    public string? Username { get; init; }
    public string? Password { get; init; }
    
    public int Port { get; init; } = 5432;

    internal string ConnectionString
        => $"Host={Host};Post={Port};Database={Database};Username={Username};Password={Password}";

    internal void ValidateConnectionString()
    {
        ArgumentNullException.ThrowIfNull(Host);
        ArgumentNullException.ThrowIfNull(Database);
        ArgumentNullException.ThrowIfNull(Username);
        ArgumentNullException.ThrowIfNull(Password);
    }
}
