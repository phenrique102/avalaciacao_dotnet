using Application.Interfaces;
using Dapper;
using Domain.Alunos;
using Domain.Planos;
using Domain.ValueObjects;
using MySqlConnector;

namespace Infrastructure.Repositories
{
    public class AlunoRepository(MySqlConnection connection, IBancoDadosRepository bancoDadosRepository)
        : Repository<Aluno>(connection, bancoDadosRepository), IAlunoRepository
    {
        private readonly MySqlConnection _connection = connection;
        const string cmdSelectAluno = "SELECT a.*, p.noPlano, p.dsPlano FROM Aluno a INNER JOIN Plano p ON p.idPlano = a.idPlano";
        public void AddAlunoComPlano(Aluno aluno)
        {
            _connection.Execute(@"INSERT INTO Aluno (noAluno, dtNascimento, dsSexo, flAtivo, dsComentario, idPlano) VALUES (@NoAluno, @DtNascimento, @DsSexo, @FlAtivo, @DsComentario, @IdPlano)",
                new { aluno.NoAluno, aluno.DtNascimento, DsSexo = aluno.DsSexo.ToString(), FlAtivo = aluno.FlAtivo.ToString(), aluno.DsComentario, aluno.Plano.IdPlano }
              );
        }

        public void AtualizaAlunoComPlano(Aluno aluno)
        {
            _connection.Execute(@"UPDATE Aluno SET noAluno = @NoAluno, dtNascimento = @DtNascimento, dsSexo = @DsSexo, flAtivo = @FlAtivo, dsComentario = @DsComentario, idPlano = @IdPlano WHERE idAluno = @IdAluno",
                new { aluno.NoAluno, aluno.DtNascimento, DsSexo = aluno.DsSexo.ToString(), FlAtivo = aluno.FlAtivo.ToString(), aluno.DsComentario, aluno.Plano.IdPlano, aluno.IdAluno }
            );
        }

        public Aluno? ObterAlunoComPlanoPorIdentificador(int idAluno)
        {
            var retorno = _connection.QueryFirstOrDefault( $"{cmdSelectAluno} WHERE idAluno = @IdAluno", new { IdAluno = idAluno });
            return retorno != null ? new Aluno
            { 
                IdAluno = retorno.idAluno,
                NoAluno = retorno.noAluno,
                DtNascimento = retorno.dtNascimento,
                DsSexo = new SexoVO(retorno.dsSexo),
                FlAtivo = new SimNaoVO(retorno.flAtivo),
                DsComentario = retorno.dsComentario,
                Plano = new Plano { IdPlano = retorno.idPlano, NoPlano = retorno.noPlano, DsPlano = retorno.dsPlano }
            } : null;
        }

        public IEnumerable<Aluno> ObterTodosAlunos()
        {
            var retorno = _connection.Query(cmdSelectAluno);
            return retorno.Select(x => new Aluno
            {
                IdAluno = x.idAluno,
                NoAluno = x.noAluno,
                DtNascimento = x.dtNascimento,
                DsSexo = new SexoVO(x.dsSexo),
                FlAtivo = new SimNaoVO(x.flAtivo),
                DsComentario = x.dsComentario,
                Plano = new Plano { IdPlano = x.idPlano, NoPlano = x.noPlano, DsPlano = x.dsPlano }
            });
        }
    }
}
