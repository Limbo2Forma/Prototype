using System.Security.Claims;

namespace Prototype.Interfaces {
    public interface IJwtAuthenticate {
        string GenerateToken(System.Collections.Generic.IEnumerable<Claim> claims);
    }
}
