using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OAuthApi.Requirement
{
    public class JwtRequirement : IAuthorizationRequirement
    {
    }

    public class JwtRequirementHandler : AuthorizationHandler<JwtRequirement>
    {
        private readonly HttpContext _httpContext;

        private readonly HttpClient _client;

        public JwtRequirementHandler(IHttpClientFactory factory, IHttpContextAccessor accessor)
        {
            _httpContext = accessor.HttpContext;
            _client = factory.CreateClient();
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            JwtRequirement requirement)
        {
            if (_httpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                var token = authHeader.ToString().Split(' ').Last();

                var response = await _client.GetAsync($"https://localhost:44363/OAuth/Validate?access_token={token}");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    context.Succeed(requirement);
                }
            }
        }
    }
}