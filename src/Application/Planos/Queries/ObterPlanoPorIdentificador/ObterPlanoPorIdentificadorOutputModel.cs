namespace Application.Planos.Queries.ObterPlanoPorIdentificador
{
    public class ObterPlanoPorIdentificadorOutputModel
    {
        public required int IdPlano { get; set; }
        public required string NoPlano { get; set; }
        public string? DsPlano { get; set; }
    }
}
