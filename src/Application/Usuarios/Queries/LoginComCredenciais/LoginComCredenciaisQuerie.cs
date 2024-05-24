using Application.Interfaces;
using Domain.Usuarios;

namespace Application.Usuarios.Queries.LoginComCredenciais
{
    public class LoginComCredenciaisQuerie(IPatternAuthenticationService patternAuthenticationService, IMapperService mapperService, ICryptService cryptService, IUsuarioRepository usuarioRepository) : ILoginComCredenciaisQuerie
    {
        public LoginComCredenciaisOutputModel Execute(LoginComCredenciaisInputModel inputModel)
        {
            if (string.IsNullOrEmpty(inputModel.DsEmail))
                throw new ApplicationException("Prop DsEmail é obrigatório");

            if (string.IsNullOrEmpty(inputModel.DsSenha))
                throw new ApplicationException("Prop DsSenha é obrigatório");

            // Não envidenciar o erro ocorrido por segurança, assim evitando de um
            // possível atacante saber se o e-mail existe na base de dados
            var usuario = usuarioRepository.GetPorEmail(inputModel.DsEmail) ?? throw new ApplicationException("Autenticação inválida");
            if (!cryptService.Verify(inputModel.DsSenha, usuario.DsSenha, usuario.DsSenhaSalt))
                throw new ApplicationException("Autenticação inválida");

            var token = patternAuthenticationService.GerarToken(usuario);
            return mapperService.Map<Token, LoginComCredenciaisOutputModel>(token);
        }
    }
}
