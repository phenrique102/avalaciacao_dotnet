using Application.Interfaces;
using Domain.Planos;

namespace Application.Planos.Queries.ObterTodosPlanos
{
    public class ObterTodosPlanosQuerie(IPlanoRepository planoRepository, IMapperService mapperService) : IObterTodosPlanosQuerie
    {
        public IEnumerable<ObterTodosPlanosOutputModel> Execute()
        {
            var planos = planoRepository.GetAll();

            return mapperService.MapList<Plano, ObterTodosPlanosOutputModel>(planos);
        }
    }
}
