using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BasicAuth.Transformer
{
    public class ClaimTransformation : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            //It's basically adding claims to the context, I do not know why we need to do this.
            throw new System.NotImplementedException();
        }
    }
}
