using Application.Interfaces;
using Domain.Alunos;

namespace Application.Alunos.Queries.ObterTodosAlunos
{
    public class ObterTodosAlunosQuerie(IAlunoRepository alunoRepository, IMapperService mapperService) : IObterTodosAlunosQuerie
    {
        public IEnumerable<ObterTodosAlunosOutputModel> Execute()
        {
            var alunos = alunoRepository.ObterTodosAlunos();

            return mapperService.MapList<Aluno, ObterTodosAlunosOutputModel>(alunos);
        }
    }
}
