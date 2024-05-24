using Application.Common.Model;

namespace Application.Alunos.Queries.ObterAlunoPorIdentificador
{
    public class ObterAlunoPorIdentificadorOutputModel
    {
        public required int IdAluno { get; set; }
        public required string NoAluno { get; set; }
        public required DateTime DtNascimento { get; set; }
        public required string DsSexo { get; init; }
        public required string FlAtivo { get; set; }
        public string? DsComentario { get; init; }
        public required PlanoDTO Plano { get; init; }
    }
}
