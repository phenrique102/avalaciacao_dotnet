using Dapper.Contrib.Extensions;
using Domain.Planos;
using Domain.ValueObjects;

namespace Domain.Alunos
{
    [Table("Aluno")]
    public sealed class Aluno
    {
        [ExplicitKey]
        public required int IdAluno { get; init; }
        public required string NoAluno { get; init; }
        public required DateTime DtNascimento { get; init; }
        public required SexoVO DsSexo { get; init; }
        public required SimNaoVO FlAtivo { get; set; }
        public string? DsComentario { get; init; }
        public required Plano Plano { get; init; }
    }
}
