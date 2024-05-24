using Application.Interfaces;
using Dapper;
using Domain.Usuarios;
using MySqlConnector;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository(MySqlConnection connection, IBancoDadosRepository bancoDadosRepository)
        : Repository<Usuario>(connection, bancoDadosRepository), IUsuarioRepository
    {
        private readonly MySqlConnection _connection = connection;

        public Usuario? GetPorEmail(string email)
        {
            return _connection.QueryFirstOrDefault<Usuario>("SELECT * FROM Usuario WHERE DsEmail = @DsEmail", new { DsEmail = email });
        }

        public Usuario? GetPorEmailNome(string email, string nome)
        {
            return _connection.QueryFirstOrDefault<Usuario>("SELECT * FROM Usuario WHERE DsEmail = @DsEmail AND DsNome = @DsNome", new { DsEmail = email, DsNome = nome });
        }
    }
}
