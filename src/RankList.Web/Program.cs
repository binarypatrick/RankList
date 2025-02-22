using RankList.Auth;
using RankList.Data;
using RankList.Data.Models;
using RankList.Services;
using RankList.Web;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(CookieAuthSchemeOptions.DefaultConfiguration)
    .AddScheme<CookieAuthSchemeOptions, CookieAuthHandler>(CookieAuthDefaults.AuthenticationScheme, options => { });

ConnectionOptions connectionOptions = builder.Configuration
    .GetSection("DatabaseConnection")
    .Bind<ConnectionOptions>();

builder.Services.AddAppData(connectionOptions);
builder.Services.AddAppServices();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.Run();