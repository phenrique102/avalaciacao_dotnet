using Web.Models.Planos;

namespace Web.Services.Plano
{
    public interface IPlanoService
    {
        Task<List<ObterTodosPlanosOutputModel>> ObterTodosPlanos();

        void ApagarPlano(int id);
    }
}
