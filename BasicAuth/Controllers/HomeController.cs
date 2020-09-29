using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BasicAuth.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public async Task<IActionResult> Authenticate()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"Andy"),
                new Claim(ClaimTypes.Email,"andy@infosoft.co.nz"),
                new Claim("custom values","something I need to know."),
            };

            var identity = new ClaimsIdentity(claims, "Cookies");

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index");
        }
    }
}
