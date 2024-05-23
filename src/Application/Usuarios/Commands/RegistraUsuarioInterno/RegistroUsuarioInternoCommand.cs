using Application.Interfaces;
using Domain.Usuarios;

namespace Application.Usuarios.Commands.RegistraUsuarioInterno
{
    public class RegistroUsuarioInternoCommand(IMapperService mapperService, IUsuarioRepository usuarioRepository) : IRegistroUsuarioInternoCommand
    {
        public void Execute(RegistroUsuarioInternoInputModel input)
        {
            var usuario = mapperService.Map<RegistroUsuarioInternoInputModel, Usuario>(input);

            if (string.IsNullOrEmpty(usuario.DsNome))
                throw new ApplicationException("Prop DsNome é obrigatório");

            if (string.IsNullOrEmpty(usuario.DsEmail))
                throw new ApplicationException("Prop DsEmail é obrigatório");

            if (string.IsNullOrEmpty(usuario.DsSenha))
                throw new ApplicationException("Prop DsSenha é obrigatório");

            if (usuario.DsSenha.Any(ch => !char.IsLetterOrDigit(ch)))
                throw new ApplicationException("A prop senha deve conter ao menos um caractere especial");

            var hasUsuario = usuarioRepository.GetPorEmailNome(usuario.DsEmail, usuario.DsNome);
            if (hasUsuario != null)
                throw new ApplicationException("Nome e e-mail de usuário já existem, por favor usar um nome e e-mail diferentes.");

            usuarioRepository.Add(usuario);
        }
    }
}
