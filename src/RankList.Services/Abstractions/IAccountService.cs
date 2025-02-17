using RankList.Common.Models;

namespace RankList.Services.Abstractions;

public interface IAccountService
{
    User? Login(string username, string password);
    User? Register(string username, string password);
    IEnumerable<User> GetUsers(int page = 0);
}