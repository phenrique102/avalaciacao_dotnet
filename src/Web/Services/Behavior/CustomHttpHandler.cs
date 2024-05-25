using Blazored.LocalStorage;

namespace Web.Services.Behavior
{
    public class CustomHttpHandler(ILocalStorageService localStorageService) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string[] urisDesconsiderar = ["login", "registrar-usuario-interno"];
            if (urisDesconsiderar.Contains(request.RequestUri.AbsolutePath.ToLower()))
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var token = await localStorageService.GetItemAsStringAsync("authToken");

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Add("Authorization", $"Bearer {token}");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
