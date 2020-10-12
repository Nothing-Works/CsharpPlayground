using Microsoft.IdentityModel.Tokens;
using System;

namespace JWT
{
    public static class JWTSettings
    {
        public static string Audience = "default Audience";
        public static string Issuer = "default Issuer";
        public static string Secret = "pintusharmaqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqweqwess";


        public static TokenValidationParameters TokenValidationParameters => new TokenValidationParameters
        {
            ClockSkew = TimeSpan.Zero,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Issuer,
            ValidAudience = Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(Secret))
        };
    }
}
