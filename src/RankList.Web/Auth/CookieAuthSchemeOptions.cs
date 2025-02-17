using Microsoft.AspNetCore.Authentication;

namespace RankList.Auth;

public class CookieAuthSchemeOptions : AuthenticationSchemeOptions
{
    public static void DefaultConfiguration(AuthenticationOptions options)
    {
        options.DefaultScheme = CookieAuthDefaults.AuthenticationScheme;
    }
}

