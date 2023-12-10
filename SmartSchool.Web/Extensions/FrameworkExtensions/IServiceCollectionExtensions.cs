using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using SmartSchool.Web.Services;

namespace SmartSchool.Web.Extensions.FrameworkExtensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddCascadingAuthenticationState();
            services.AddScoped<AuthenticationStateProvider, AuthStateRevalidation>();

            services.AddAuthentication(opt  =>
            {
                opt.DefaultScheme = IdentityConstants.ApplicationScheme;
                opt.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
                opt.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
            })
                .AddIdentityCookies();

            services.AddScoped<CookieEvents>();
            services.ConfigureApplicationCookie(options =>
            {
                options.EventsType = typeof(CookieEvents);
            });

            services.AddAuthorization();

            return services;
        }
    }
}
