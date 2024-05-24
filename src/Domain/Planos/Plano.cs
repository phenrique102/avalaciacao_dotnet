using Dapper.Contrib.Extensions;

namespace Domain.Planos
{
    [Table("Plano")]
    public sealed class Plano
    {
        [ExplicitKey]
        public required int IdPlano { get; init; }
        public required string NoPlano { get; init; }
        public string? DsPlano { get; init; }
    }
}
