using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RankList.Auth;
using RankList.Common.Interfaces;
using RankList.Common.Services;
using RankList.Data.Database;

namespace RankList.Web.Pages;

[Authorize(AuthenticationSchemes = CookieAuthDefaults.AuthenticationScheme)]
public class IndexModel(ILogger<IndexModel> logger, AppDbContext dbContext, IToastManager toastManager) : PageModel
{
    public void OnGet()
    {
        try
        {
//            int t = dbContext.Users.Count();
        }
        catch (Exception ex)
        {
            toastManager.AddToast(ex.Message);
            ModelState.AddModelError(string.Empty, ex.Message);
        }
    }
}