namespace Application.Planos.Queries.ObterTodosPlanos
{
    public interface IObterTodosPlanosQuerie
    {
        IEnumerable<ObterTodosPlanosOutputModel> Execute();
    }
}
