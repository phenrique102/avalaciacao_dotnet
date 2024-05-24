using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Web.Services.Authentication
{
    public class ApiAuthenticationStateProvider(ILocalStorageService localStorage) : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var tokenSalvo = await localStorage.GetItemAsync<string>("authToken");
            var tokenExpiracao = await localStorage.GetItemAsync<string>("authTokenExpiracao");

            if (string.IsNullOrWhiteSpace(tokenSalvo) || TokenExpirou(tokenExpiracao))
            {
                MarkUserAsLoggedOut();
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(tokenSalvo), "jwt")));
        }

        public void MarkUserAsAuthenticated(string token)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public void MarkUserAsLoggedOut()
        { 
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }

        private bool TokenExpirou(string tokenExpiracao)
        {
            var dataExpiracao = DateTime.ParseExact(tokenExpiracao, "yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'", null, DateTimeStyles.RoundtripKind);
            if (dataExpiracao < DateTime.UtcNow)
            {
                return true;
            }
            return false;
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwt);
            return token.Claims;
        }
    }
}
