using BasicAuth.AuthorizationRequirements;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace BasicAuth
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //also consider these examples for cookie auth
            //https://docs.microsoft.com/en-gb/aspnet/core/security/authentication/cookie?view=aspnetcore-3.1
            //https://docs.microsoft.com/en-gb/aspnet/core/security/authentication/samples?view=aspnetcore-3.1
            //This for token auth
            //https://github.com/davidfowl/Todos

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                    o =>
                    {
                        o.Cookie.Name = "Andy";
                        o.LoginPath = "/Home/Authenticate";
                    });

            services.AddAuthorization(o =>
            {
                //this is the default one.
                // o.DefaultPolicy = new AuthorizationPolicyBuilder()
                //     .RequireAuthenticatedUser()
                //     .RequireClaim(ClaimTypes.DateOfBirth)
                //     .Build();

                o.AddPolicy("Claim.DoB", builder =>
                {
                    builder.AddRequirements(new CustomRequireClaim(ClaimTypes.DateOfBirth));
                });
            });

            services.AddScoped<IAuthorizationHandler, CustomRequireClaimHandler>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }
    }
}