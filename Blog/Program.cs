using Blog.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var scope = host.Services.CreateScope();

            var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            _context.Database.EnsureCreated();

            var adminRole = new IdentityRole("Admin");

            if (!_context.Roles.Any())
            {
                _roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
            }

            if (!_context.Users.Any(c => c.UserName == "admin@test.com"))
            {
                var adminUser = new IdentityUser
                {
                    UserName = "admin@test.com",
                    Email = "admin@test.com",
                    EmailConfirmed = true
                };

                _userManager.CreateAsync(adminUser, "Rooney!1").GetAwaiter().GetResult();

                _userManager.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}