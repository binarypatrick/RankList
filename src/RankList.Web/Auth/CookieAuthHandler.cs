using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace RankList.Auth;

public class CookieAuthHandler(
    IOptionsMonitor<CookieAuthSchemeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder)
    : AuthenticationHandler<CookieAuthSchemeOptions>(options, logger, encoder)
{
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        List<Claim> claims = [new(ClaimTypes.Name, "me")];
        ClaimsIdentity identity = new(claims, nameof(CookieAuthHandler));
        ClaimsPrincipal principal = new(identity);
        AuthenticationTicket ticket = new(principal, CookieAuthDefaults.AuthenticationScheme);
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}