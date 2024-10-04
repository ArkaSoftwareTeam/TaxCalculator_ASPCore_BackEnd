using System.Security.Claims;

namespace CTaxCalculator.Framework.Endpoints.Web.Extensions.Common
{
    public static class ClaimExtensions
    {
        public static string GetClaim(this ClaimsPrincipal userClaimsPrincipal, string claimType)
        {
            return userClaimsPrincipal.Claims?.FirstOrDefault((x) => x.Type == claimType)!.Value!;
        }
    }
}
