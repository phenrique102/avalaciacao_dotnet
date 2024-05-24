using Application.Interfaces;
using Domain.Planos;

namespace Application.Planos.Commands.RegistraPlanoSimples
{
    public class RegistraPlanoSimplesCommand(IMapperService mapperService, IPlanoRepository planoRepository) : IRegistraPlanoSimplesCommand
    {
        public void Execute(RegistraPlanoSimplesInputModel inputModel)
        {
            if (string.IsNullOrEmpty(inputModel.NoPlano))
                throw new ApplicationException("Prop NoPlano é obrigatório");

            var plano = mapperService.Map<RegistraPlanoSimplesInputModel, Plano>(inputModel);
            planoRepository.Add(plano);
        }
    }
}
