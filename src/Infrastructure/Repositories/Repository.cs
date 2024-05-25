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

        public virtual void Add(T entity)
        {
            _connection.Insert(entity);
        }

        public void Delete(T entity)
        {
            _connection.Delete(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _connection.GetAll<T>();
        }

        public virtual T GetById(int id)
        {
            return _connection.Get<T>(id);
        }

        public void Update(T entity)
        {
            _connection.Update(entity);
        }
    }
}
