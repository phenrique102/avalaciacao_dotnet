using Application.Interfaces;
using Domain.Planos;

namespace Application.Planos.Commands.AtualizarPlanoSimples
{
    public class AtualizarPlanoSimplesCommand(IMapperService mapperService, IPlanoRepository planoRepository) : IAtualizarPlanoSimplesCommand
    {
        public void Execute(AtualizarPlanoSimplesInputModel inputModel)
        {
            if (inputModel.IdPlano <= 0)
                throw new ApplicationException("Prop IdPlano é obrigatório");

            if (string.IsNullOrEmpty(inputModel.NoPlano))
                throw new ApplicationException("Prop NoPlano é obrigatório");

            var plano = mapperService.Map<AtualizarPlanoSimplesInputModel, Plano>(inputModel);
            planoRepository.AtualizaPlano(plano);
        }
    }
}
