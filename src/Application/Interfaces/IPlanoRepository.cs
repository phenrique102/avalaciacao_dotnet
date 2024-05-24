using Domain.Planos;

namespace Application.Interfaces
{
    public interface IPlanoRepository : IRepository<Plano>
    {
        bool ExistePlano(int idPlano);

        void AtualizaPlano(Plano plano);
    }
}
