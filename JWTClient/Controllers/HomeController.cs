using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace JWTClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;

        public HomeController(IHttpClientFactory client)
        {
            _client = client.CreateClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Secret()
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var response = await _client.GetAsync("https://localhost:44363/Home/Secret");


            var response1 = await _client.GetAsync("https://localhost:44362/Home/Secret");


            return View();
        }

        public IActionResult Callback()
        {
            return RedirectToAction("Index");
        }
    }
}
