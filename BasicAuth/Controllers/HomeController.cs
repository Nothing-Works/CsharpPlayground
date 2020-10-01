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
        private readonly IAuthorizationService _authorizationService;

        public HomeController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _authorizationService.AuthorizeAsync(User, "Claim.DoB");

            if (result.Succeeded)
            {
                ViewBag.Greeting = "Hello";
            }

            return View();
        }


        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "Claim.DoB")]
        public IActionResult DoB()
        {
            return View();
        }

        [Authorize(Policy = "Claim.DoB1")]
        public IActionResult DoB1()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        //For "Roles" is checking the value under "Role" from the claim.
        //or The "value" under role manager.
        public IActionResult Role()
        {
            return View();
        }

        public async Task<IActionResult> Authenticate()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Andy"),
                new Claim(ClaimTypes.Email, "andy@infosoft.co.nz"),
                new Claim(ClaimTypes.DateOfBirth, "andy@infosoft.co.nz"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim("Andy", "Admin"),
                new Claim("custom values", "something I need to know."),
            };

            var identity = new ClaimsIdentity(claims, "Cookies");

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index");
        }
    }
}