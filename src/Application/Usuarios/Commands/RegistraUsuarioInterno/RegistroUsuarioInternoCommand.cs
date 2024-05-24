using Application.Interfaces;
using Domain.Usuarios;

namespace Application.Usuarios.Commands.RegistraUsuarioInterno
{
    public class RegistroUsuarioInternoCommand(
        IMapperService mapperService, 
        IUsuarioRepository usuarioRepository,
        ICryptService cryptService) : IRegistroUsuarioInternoCommand
    {
        public void Execute(RegistroUsuarioInternoInputModel input)
        {
            if (string.IsNullOrEmpty(input.DsNome))
                throw new ApplicationException("Prop DsNome é obrigatório");

            if (string.IsNullOrEmpty(input.DsEmail))
                throw new ApplicationException("Prop DsEmail é obrigatório");

            if (string.IsNullOrEmpty(input.DsSenha))
                throw new ApplicationException("Prop DsSenha é obrigatório");

            if (input.DsSenha.Length < 12)
                throw new ApplicationException("A prop DsSenha deve conter ao menos 12 caracteres");

            var hasUsuario = usuarioRepository.GetPorEmailNome(input.DsEmail, input.DsNome);
            if (hasUsuario != null)
                throw new ApplicationException("Nome e e-mail de usuário já existem, por favor usar um nome e e-mail diferentes.");

            var usuario = mapperService.Map<RegistroUsuarioInternoInputModel, Usuario>(input);
            usuario.DsSenhaSalt = cryptService.GenerateSalt();
            usuario.DsSenha = cryptService.Hash(input.DsSenha, usuario.DsSenhaSalt);

            usuarioRepository.Add(usuario);
        }
    }
}
