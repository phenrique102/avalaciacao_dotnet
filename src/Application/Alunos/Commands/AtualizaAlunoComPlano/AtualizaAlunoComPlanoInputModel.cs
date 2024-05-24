namespace Application.Alunos.Commands.AtualizaAlunoComPlano
{
    public class AtualizaAlunoComPlanoInputModel
    {
        public required int IdAluno { get; set; }
        public required string NoAluno { get; set; }
        public required DateTime DtNascimento { get; set; }
        public required string DsSexo { get; set; }
        public required string FlAtivo { get; set; }
        public string? DsComentario { get; set; }
        public required int IdPlano { get; set; }
    }
}
