using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Role()
        {
            return View();
        }

        [Authorize(Roles = "Admin1")]
        public IActionResult Role1()
        {
            return View();
        }


        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");

                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            var role = new IdentityRole();
            role.Name = "Admin1";
            await _roleManager.CreateAsync(role);

            var user = new IdentityUser
            {
                UserName = username,
                Email = ""
            };

            var result = await _userManager.CreateAsync(user, password);
            var claim = await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Admin"));
            await _userManager.AddToRoleAsync(user, "Admin1");

            if (result.Succeeded && claim.Succeeded)
            {
                var sign = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (sign.Succeeded)
                {
                    return RedirectToAction("Index");

                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }
    }
}
