using Domain.Alunos;

namespace Application.Interfaces
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        void AddAlunoComPlano(Aluno aluno);
        void AtualizaAlunoComPlano(Aluno aluno);
        Aluno? ObterAlunoComPlanoPorIdentificador(int idAluno);
        IEnumerable<Aluno> ObterTodosAlunos();
    }
}
