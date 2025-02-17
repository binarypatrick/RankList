using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RankList.Auth;
using RankList.Data.Database;

namespace RankList.Pages;

[Authorize(AuthenticationSchemes = CookieAuthDefaults.AuthenticationScheme)]
public class IndexModel(ILogger<IndexModel> logger, AppDbContext dbContext) : PageModel
{
    public void OnGet()
    {
        var t = dbContext.Users.Count();
    }
}