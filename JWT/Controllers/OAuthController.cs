using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Controllers
{
    public class OAuthController : Controller
    {
        [HttpGet]
        public IActionResult Authorize(
            string response_type,
            string client_id,
            string redirect_uri,
            string scope,
            string state
        )
        {
            var query = new QueryBuilder { { "redirect_uri", redirect_uri }, { "state", state } };

            return View(model: query.ToString());
        }


        [HttpPost]
        public IActionResult Authorize(
            string username,
            string password,
            string redirect_uri,
            string state
        )
        {
            const string code = "OAuth Code";
            var query = new QueryBuilder { { "code", code }, { "state", state } };

            return Redirect($"{redirect_uri}{query}");
        }

        public async Task<IActionResult> Token(
            string grant_type,
            string code,
            string redirect_uri,
            string client_id
            )
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, "id=1"),
                new Claim("Andy", "Song"),
            };

            var key = new SymmetricSecurityKey(Convert.FromBase64String(JWTSettings.Secret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                JWTSettings.Issuer,
                JWTSettings.Audience,
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                creds
            );

            var responseObject = new { access_token = new JwtSecurityTokenHandler().WriteToken(token), token_type = "Bearer" };

            var responseJson = JsonConvert.SerializeObject(responseObject);
            var responseBytes = Encoding.UTF8.GetBytes(responseJson);

            await Response.Body.WriteAsync(responseBytes, 0, responseBytes.Length);

            return Redirect(redirect_uri);
        }
    }
}