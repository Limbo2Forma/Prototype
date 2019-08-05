using System.Security.Claims;

namespace Prototype.Interfaces {
    public interface IJwtAuthenticate {
        string GenerateAccessToken(System.Collections.Generic.IEnumerable<Claim> claims);
    }
}
