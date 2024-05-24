namespace Application.Planos.Queries.ObterPlanoPorIdentificador
{
    public interface IObterPlanoPorIdentificadorQuerie
    {
        ObterPlanoPorIdentificadorOutputModel Execute(int idPlano);
    }
}
