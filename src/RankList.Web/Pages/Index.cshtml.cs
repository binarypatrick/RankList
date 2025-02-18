using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RankList.Auth;
using RankList.Common.Services;
using RankList.Data.Database;

namespace RankList.Pages;

[Authorize(AuthenticationSchemes = CookieAuthDefaults.AuthenticationScheme)]
public class IndexModel(ILogger<IndexModel> logger, AppDbContext dbContext) : PageModel
{
    public void OnGet()
    {
        try
        {
            var t = dbContext.Users.Count();
        }
        catch (Exception ex)
        {
            ToastManager.Instance.AddToast(ex.Message);
            ModelState.AddModelError(string.Empty, ex.Message);
        }
    }
}