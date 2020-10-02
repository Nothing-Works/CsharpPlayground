using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace JWT.Controllers
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
            return Ok("done");
        }

        public IActionResult Authenticate()
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

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}