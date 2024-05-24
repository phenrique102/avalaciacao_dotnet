namespace Application.Alunos.Queries.ObterAlunoPorIdentificador
{
    public interface IObterAlunoPorIdentificadorQuerie
    {
        ObterAlunoPorIdentificadorOutputModel Execute(int idAluno);
    }
}
