namespace Application.Planos.Commands.AtualizarPlanoSimples
{
    public class AtualizarPlanoSimplesInputModel
    {
        public required int IdPlano { get; set; }
        public required string NoPlano { get; set; }
        public string? DsPlano { get; set; }
    }
}
