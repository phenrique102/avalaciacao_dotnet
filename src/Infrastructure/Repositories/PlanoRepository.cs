using Application.Interfaces;
using Dapper;
using Domain.Planos;
using MySqlConnector;

namespace Infrastructure.Repositories
{
    public class PlanoRepository(MySqlConnection connection, IBancoDadosRepository bancoDadosRepository) : Repository<Plano>(connection, bancoDadosRepository), IPlanoRepository
    {
        private readonly MySqlConnection _connection = connection;

        public void AtualizaPlano(Plano plano)
        {
            _connection.Execute(@"UPDATE Plano SET noPlano = @NoPlano, dsPlano = @DsPlano WHERE idPlano = @IdPlano",
                new { plano.NoPlano, plano.DsPlano, plano.IdPlano }
            );
        }

        public bool ExistePlano(int idPlano)
        {
            var command = new MySqlCommand("SELECT COUNT(*) FROM Plano WHERE idPlano = @id", _connection);
            command.Parameters.AddWithValue("@id", idPlano);

            var count = Convert.ToInt32(command.ExecuteScalar());

            return count > 0;
        }
    }
}
