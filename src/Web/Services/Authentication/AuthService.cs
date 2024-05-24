using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Web.Models;

namespace Web.Services.Authentication
{
    public class AuthService(IHttpClientFactory httpClientFactory, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorageService) : IAuthService
    {
        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            try
            {
                var httpClient = httpClientFactory.CreateClient("ApiAcademia");
                var loginModelJson = JsonSerializer.Serialize(loginModel);
                var requestContent = new StringContent(loginModelJson, Encoding.UTF8, "application/json");

                var responseMessage = await httpClient.PostAsync("api/usuario/login", requestContent);
                var loginResultJson = JsonSerializer.Deserialize<LoginResult>(await responseMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (!responseMessage.IsSuccessStatusCode)
                {
                    return loginResultJson;
                }

                await localStorageService.SetItemAsStringAsync("authToken", loginResultJson.AccessToken);
                await localStorageService.SetItemAsStringAsync("authTokenExpiracao", loginResultJson.Expires);

                ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(loginResultJson.AccessToken);

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(loginResultJson.TokenType, loginResultJson.AccessToken);

                return loginResultJson;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Logout()
        {
            var httpClient = httpClientFactory.CreateClient("ApiAcademia");
            await localStorageService.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsLoggedOut();
            httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
