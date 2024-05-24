using Application.Interfaces;
using MySqlConnector;
using Dapper.Contrib.Extensions;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MySqlConnection _connection;

        public Repository(MySqlConnection connection, IBancoDadosRepository bancoDadosRepository)
        {
            _connection = connection;
            bancoDadosRepository.Inicializar();
        }

        public void Add(T entity)
        {
            _connection.Insert(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _connection.GetAll<T>();
        }
    }
}
