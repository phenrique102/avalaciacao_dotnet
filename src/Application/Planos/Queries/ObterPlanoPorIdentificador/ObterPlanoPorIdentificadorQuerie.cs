using Application.Interfaces;
using Domain.Planos;

namespace Application.Planos.Queries.ObterPlanoPorIdentificador
{
    public class ObterPlanoPorIdentificadorQuerie(IPlanoRepository planoRepository, IMapperService mapperService) : IObterPlanoPorIdentificadorQuerie
    {
        public ObterPlanoPorIdentificadorOutputModel Execute(int idPlano)
        {
            if (idPlano <= 0)
            {
                throw new ApplicationException("Parâmetro idPlano é obrigatório");
            }

            var plano = planoRepository.GetById(idPlano);
            return mapperService.Map<Plano, ObterPlanoPorIdentificadorOutputModel>(plano);
        }
    }
}
