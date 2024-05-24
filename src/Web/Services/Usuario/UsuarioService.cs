using System.Text;
using System.Text.Json;
using Web.Models.Usuarios;

namespace Web.Services.Usuario
{
    public class UsuarioService(IHttpClientFactory httpClientFactory) : IUsuarioService
    {
        public async Task<RegistrarUsuarioInternoOutputModel> RegistrarUsuarioInterno(RegistrarUsuarioInternoInputModel usuarioModel)
        {
            var httpClient = httpClientFactory.CreateClient("ApiAcademia");
            var loginModelJson = JsonSerializer.Serialize(usuarioModel);
            var requestContent = new StringContent(loginModelJson, Encoding.UTF8, "application/json");

            var responseMessage = await httpClient.PostAsync("api/usuario/registrar-usuario-interno", requestContent);
            if (!responseMessage.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<RegistrarUsuarioInternoOutputModel>(await responseMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return new RegistrarUsuarioInternoOutputModel();
        }
    }
}
