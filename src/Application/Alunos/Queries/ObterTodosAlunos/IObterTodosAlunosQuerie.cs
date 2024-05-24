namespace Application.Alunos.Queries.ObterTodosAlunos
{
    public interface IObterTodosAlunosQuerie
    {
        IEnumerable<ObterTodosAlunosOutputModel> Execute();
    }
}
