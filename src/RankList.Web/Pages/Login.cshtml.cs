using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RankList.Common.Models;
using RankList.Forms;
using RankList.Services.Abstractions;

namespace RankList.Pages;

public class LoginModel(ILogger<LoginModel> logger, IAccountService accountService) : PageModel
{
    public IEnumerable<User> Users = [];
    
    public void OnGet()
    {
        Users = accountService.GetUsers();
    }

    [BindProperty] public LoginForm? LoginForm { get; set; } = new LoginForm();
    public void OnPost()
    {
        LoginForm? t = LoginForm;
    }
}