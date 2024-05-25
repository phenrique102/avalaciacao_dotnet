using Application.Interfaces;
using Domain.Alunos;

namespace Application.Alunos.Commands.ApagarAlunoComPlano
{
    public class ApagarAlunoComPlanoCommand(IAlunoRepository alunoRepository) : IApagarAlunoComPlanoCommand
    {
        public void Execute(int id)
        {
            if (id <= 0)
                throw new ApplicationException("O campo Id é obrigatório");

            var aluno = alunoRepository.ObterAlunoComPlanoPorIdentificador(id) ?? throw new ApplicationException("Aluno não encontrado");
            alunoRepository.Delete(aluno);
        }
    }
}
