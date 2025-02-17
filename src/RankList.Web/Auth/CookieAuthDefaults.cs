namespace RankList.Auth;

public class CookieAuthDefaults
{
    /// <summary>
    ///     The default value used for CookieAuthenticationOptions.AuthenticationScheme
    /// </summary>
    public const string AuthenticationScheme = "rank-list-cookie";

    /// <summary>
    ///     The prefix used to provide a default CookieAuthenticationOptions.CookieName
    /// </summary>
    public static readonly string CookiePrefix = ".rank-list.";

    /// <summary>
    ///     The default value used by CookieAuthenticationMiddleware for the
    ///     CookieAuthenticationOptions.LoginPath
    /// </summary>
    public static readonly PathString LoginPath = new("/login");

    /// <summary>
    ///     The default value used by CookieAuthenticationMiddleware for the
    ///     CookieAuthenticationOptions.LogoutPath
    /// </summary>
    public static readonly PathString LogoutPath = new("/logout");

    /// <summary>
    ///     The default value used by CookieAuthenticationMiddleware for the
    ///     CookieAuthenticationOptions.AccessDeniedPath
    /// </summary>
    public static readonly PathString AccessDeniedPath = new("/error?403");

    /// <summary>
    ///     The default value of the CookieAuthenticationOptions.ReturnUrlParameter
    /// </summary>
    public static readonly string ReturnUrlParameter = "ReturnUrl";
}