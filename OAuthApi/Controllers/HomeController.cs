using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OAuthApi.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Secret()
        {
            return Ok("done");
        }
    }
}
