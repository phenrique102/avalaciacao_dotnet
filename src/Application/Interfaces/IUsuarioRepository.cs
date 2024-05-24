using Domain.Usuarios;

namespace Application.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario? GetPorEmailNome(string email, string nome);
        Usuario? GetPorEmail(string email);
    }
}
