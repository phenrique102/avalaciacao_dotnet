using System.Net.Http.Json;
using Web.Models.Planos;

namespace Web.Services.Plano
{
    public class PlanoService(IHttpClientFactory httpClientFactory) : IPlanoService
    {
        public async void ApagarPlano(int id)
        {
            var httpClient = httpClientFactory.CreateClient("ApiAcademia");
            await httpClient.DeleteAsync($"api/plano/apagar-plano-simples/{id}");
        }

        public async Task<List<ObterTodosPlanosOutputModel>> ObterTodosPlanos()
        {
            var httpClient = httpClientFactory.CreateClient("ApiAcademia");
            var responseMessage = await httpClient.GetFromJsonAsync<List<ObterTodosPlanosOutputModel>>("api/plano/obter-todos-planos");
            return responseMessage;
        }
    }
}
