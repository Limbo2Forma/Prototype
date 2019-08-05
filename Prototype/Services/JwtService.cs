using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Prototype.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Prototype.Services {
    public class JwtService : IJwtAuthenticate {
        private readonly JwtToken jwtToken;
        public string refresh;

        public JwtService(IOptions<JwtToken> token) {
            jwtToken = token.Value;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims) {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtToken.Secret));
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Issuer = jwtToken.Issuer,
                SigningCredentials = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256Signature)
            };
            var stoken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(stoken);
        }
    }

    public class JwtToken {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public int AccessExpiration { get; set; }
    }
}
