using Application.Interfaces;

namespace Application.Planos.Commands.ApagarPlanoSimples
{
    public class ApagarPlanoSimplesCommand(IPlanoRepository planoRepository) : IApagarPlanoSimplesCommand
    {
        public void Execute(int id)
        {
            if (id <= 0)
                throw new ApplicationException("O campo Id é obrigatório");

            var plano = planoRepository.GetById(id) ?? throw new ApplicationException("Plano não encontrado");
            planoRepository.Delete(plano);
        }
    }
}
