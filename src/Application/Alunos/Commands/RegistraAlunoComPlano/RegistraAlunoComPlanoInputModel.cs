namespace Application.Alunos.Commands.RegistraAlunoComPlano
{
    public class RegistraAlunoComPlanoInputModel
    {
        public required string NoAluno { get; set; }
        public required DateTime DtNascimento { get; set; }
        public required string DsSexo { get; set; }
        public string? DsComentario { get; init; }
        public required int IdPlano { get; set; }
    }
}
