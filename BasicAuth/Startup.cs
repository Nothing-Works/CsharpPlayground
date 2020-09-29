using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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