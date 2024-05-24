using Web.Models.Usuarios;

namespace Web.Services.Usuario
{
    public interface IUsuarioService
    {
        Task<RegistrarUsuarioInternoOutputModel> RegistrarUsuarioInterno(RegistrarUsuarioInternoInputModel usuarioModel);
    }
}
