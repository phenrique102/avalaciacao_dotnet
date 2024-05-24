using Application.Interfaces;
using MySqlConnector;
using System.Data;

namespace Infrastructure.Repositories
{
    public class BancoDadosRepository(MySqlConnection connection) : IBancoDadosRepository
    {
        private readonly MySqlConnection _connection = connection;
        public void Inicializar()
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
        }
    }
}
