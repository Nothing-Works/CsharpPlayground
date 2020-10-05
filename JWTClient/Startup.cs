using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTClient
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(o =>
                {
                    o.DefaultChallengeScheme = "OAuthServer";
                    o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOAuth("OAuthServer", o =>
                {
                    o.CallbackPath = new PathString("/Home/Callback");
                    o.ClientId = "Provider:ClientId";
                    o.ClientSecret = "Provider:ClientSecret";
                    o.AuthorizationEndpoint = "https://localhost:44363/OAuth/Authorize";
                    o.TokenEndpoint = "https://localhost:44363/OAuth/Token";
                    o.SaveTokens = true;

                    o.Events = new OAuthEvents
                    {
                        OnCreatingTicket = context =>
                        {
                            var accessToken = context.AccessToken;
                            var payload = accessToken.Split('.')[1];
                            var bytes = Convert.FromBase64String(payload.PadRight(payload.Length + (payload.Length * 3) % 4, '='));
                            var jsonPayload = Encoding.UTF8.GetString(bytes);
                            var claims = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonPayload);

                            foreach (var (key, value) in claims)
                            {
                                context.Identity.AddClaim(new Claim(key, value));
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddHttpClient();

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
