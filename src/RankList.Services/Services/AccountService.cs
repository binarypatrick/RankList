using RankList.Common.Models;
using RankList.Data.Database;
using RankList.Services.Abstractions;

namespace RankList.Services.Services;

internal class AccountService(AppDbContext context) : IAccountService
{
    public User? Login(string username, string password)
    {
        User? user = context.Users.FirstOrDefault(x => x.Username == username);
        return user;
    }

    public User? Register(string username, string password)
    {
        User user = new()
        {
            UserId = Guid.CreateVersion7(),
            Username = username,
            Email = string.Empty,
            Hash = string.Empty,
            CreatedOn = DateTimeOffset.UtcNow,
        };
        
        context.Users.Add(user);
        context.SaveChanges();
        
        return user;
    }

    public IEnumerable<User> GetUsers(int page = 0)
    {
        const int pageSize = 5;
        return context.Users
            .OrderBy(x => x.Username)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
    }
}