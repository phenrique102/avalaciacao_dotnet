using Application.Usuarios.Queries.LoginComCredenciais;
using AutoMapper;
using Domain.Usuarios;

namespace Infrastructure.Profiles
{
    public class AutenticacaoProfile : Profile
    {
        public AutenticacaoProfile() 
        {
            CreateMap<Token, LoginComCredenciaisOutputModel>();
        }
    }
}
