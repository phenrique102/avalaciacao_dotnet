namespace Application.Planos.Queries.ObterTodosPlanos
{
    public class ObterTodosPlanosOutputModel
    {
        public required int IdPlano { get; set; }
        public required string NoPlano { get; set; }
        public string? DsPlano { get; set; }
    }
}
