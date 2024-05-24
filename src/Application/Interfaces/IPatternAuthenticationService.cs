using Domain.Usuarios;

namespace Application.Interfaces
{
    public interface IPatternAuthenticationService
    {
        Token GerarToken(Usuario usuario);
    }
}
