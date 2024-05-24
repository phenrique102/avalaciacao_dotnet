using Application.Usuarios.Commands.RegistraUsuarioInterno;
using AutoMapper;
using Domain.Usuarios;

namespace Infrastructure.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<RegistroUsuarioInternoInputModel, Usuario>();
        }
    }
}
