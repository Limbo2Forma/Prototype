using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Prototype.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Prototype.Services {

    public class ApiKey {
        public ApiKey(string key) {
            Key = key ?? throw new ArgumentNullException(nameof(key));
        }
        public string Key { get; }
    }

    public class ApiKeyOptions : AuthenticationSchemeOptions {
        public const string DefaultScheme = "API Key";
        public string Scheme => DefaultScheme;
        public string AuthenticationType = DefaultScheme;
    }

    public class ApiKeyHandler : AuthenticationHandler<ApiKeyOptions> {
        private const string ProblemDetailsContentType = "application/problem+json";
        private readonly IGetAllApiKeysQuery _getAllApiKeysQuery;
        private const string ApiKeyHeaderName = "X-Api-Key";
        public ApiKeyHandler(
            IOptionsMonitor<ApiKeyOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IGetAllApiKeysQuery getAllApiKeysQuery) : base(options, logger, encoder, clock) {
            _getAllApiKeysQuery = getAllApiKeysQuery ?? throw new ArgumentNullException(nameof(getAllApiKeysQuery));
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync() {
            if (!Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKeyHeaderValues)) {
                return AuthenticateResult.NoResult();
            }

            var providedApiKey = apiKeyHeaderValues.FirstOrDefault();

            if (apiKeyHeaderValues.Count == 0 || string.IsNullOrWhiteSpace(providedApiKey)) {
                return AuthenticateResult.NoResult();
            }

            var existingApiKeys = await _getAllApiKeysQuery.ExecuteAsync();

            if (existingApiKeys.ContainsKey(providedApiKey)) {
                var apiKey = existingApiKeys[providedApiKey];

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, "authorized")
                };
                
                var identity = new ClaimsIdentity(claims, Options.AuthenticationType);
                var identities = new List<ClaimsIdentity> { identity };
                var principal = new ClaimsPrincipal(identities);
                var ticket = new AuthenticationTicket(principal, Options.Scheme);

                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("Invalid API Key provided.");
        }
    }
}
