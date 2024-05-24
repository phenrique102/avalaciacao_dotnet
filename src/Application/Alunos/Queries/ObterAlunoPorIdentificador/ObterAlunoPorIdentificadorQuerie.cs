using Application.Interfaces;
using Domain.Alunos;

namespace Application.Alunos.Queries.ObterAlunoPorIdentificador
{
    public class ObterAlunoPorIdentificadorQuerie(IMapperService mapperService, IAlunoRepository alunoRepository) : IObterAlunoPorIdentificadorQuerie
    {
        public ObterAlunoPorIdentificadorOutputModel Execute(int idAluno)
        {
            if (idAluno <= 0)
            {
                throw new ApplicationException("Parâmetro idAluno é obrigatório");
            }

            var aluno = alunoRepository.ObterAlunoComPlanoPorIdentificador(idAluno);
            return mapperService.Map<Aluno, ObterAlunoPorIdentificadorOutputModel>(aluno);
        }
    }
}
