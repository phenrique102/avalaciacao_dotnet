using Application.Interfaces;
using Domain.Usuarios;

namespace Application.Usuarios.Commands.RegistraUsuarioInterno
{
    public class RegistroUsuarioInternoCommand(IMapperService mapperService, IUsuarioRepository usuarioRepository) : IRegistroUsuarioInternoCommand
    {
        public void Execute(RegistroUsuarioInternoInputModel input)
        {
            var usuario = mapperService.Map<RegistroUsuarioInternoInputModel, Usuario>(input);
            usuario.Validar();

            var hasUsuario = usuarioRepository.GetPorEmailNome(usuario.DsEmail, usuario.DsNome);
            if (hasUsuario != null)
                throw new ApplicationException("Nome e e-mail de usuário já existem, por favor usar um nome e e-mail diferentes.");

            usuarioRepository.Add(usuario);
        }
    }
}
