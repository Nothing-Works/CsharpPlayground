using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JWTClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;

        private readonly IHttpClientFactory _factory;

        public HomeController(IHttpClientFactory client)
        {
            _factory = client;
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

            var a = await RefreshAccessToken();

            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var response = await _client.GetAsync("https://localhost:44363/Home/Secret");

            var response1 = await _client.GetAsync("https://localhost:44362/Home/Secret");

            return View();
        }

        public async Task<string> RefreshAccessToken()
        {
            var refresh_token = await HttpContext.GetTokenAsync("refresh_token");

            var Client = _factory.CreateClient();

            var data = new Dictionary<string, string>
            {
                ["grant_type"] = "refresh_token",
                ["refresh_token"] = refresh_token
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44363/OAuth/Token")
            {
                Content = new FormUrlEncodedContent(data)
            };

            var basicCredentials = "username:password";
            var encoded = Encoding.UTF8.GetBytes(basicCredentials);
            var base64 = Convert.ToBase64String(encoded);

            request.Headers.Add("Authorization", $"Basic {base64}");

            var reponse = await Client.SendAsync(request);
            var responsestring = await reponse.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<Dictionary<string, string>>(responsestring);

            var newAccessToken = responseData.GetValueOrDefault("access_token");
            var newRefreshToken = responseData.GetValueOrDefault("refresh_token");

            var authInfo = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            authInfo.Properties.UpdateTokenValue("access_token", newAccessToken);
            authInfo.Properties.UpdateTokenValue("refresh_token", newRefreshToken);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, authInfo.Principal,
                authInfo.Properties);
            return "done";
        }

        public IActionResult Callback()
        {
            return RedirectToAction("Index");
        }
    }
}