using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Wko.BabyTracker.Core.DAL;
using Wko.BabyTracker.Web.Features.Identity;

namespace Wko.BabyTracker.Web.Extensions;

public static class HostExtensions
{
    public static WebApplicationBuilder AddApplicationBuilder(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContextFactory<BabyTrackerDbContext>(options => options.UseSqlite(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                        .AddEntityFrameworkStores<BabyTrackerDbContext>();
        builder.Services.AddRazorPages(options => options.RootDirectory = "/Features");
        builder.Services.AddServerSideBlazor();
        builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

        builder.Services.Configure<RazorViewEngineOptions>(options =>
        {
            options.AreaViewLocationFormats.Add($"/Features/Identity/{{1}}/{{0}}{RazorViewEngine.ViewExtension}");
            options.AreaPageViewLocationFormats.Add($"/Features/Identity/Pages/Shared/{{1}}/{{0}}{RazorViewEngine.ViewExtension}");
        });

        return builder;
    }
}
