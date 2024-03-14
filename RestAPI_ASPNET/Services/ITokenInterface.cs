using System.Security.Claims;

namespace RestAPI_ASPNET.Services
{
    public interface ITokenInterface
    {
        string GenerateAcessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken( string token);
    }
}
