using Application.Common.Model;
using Application.Planos.Commands.AtualizarPlanoSimples;
using Application.Planos.Commands.RegistraPlanoSimples;
using Application.Planos.Queries.ObterPlanoPorIdentificador;
using Application.Planos.Queries.ObterTodosPlanos;
using AutoMapper;
using Domain.Planos;

namespace Infrastructure.Profiles
{
    public class PlanoProfile : Profile
    {
        public PlanoProfile() 
        {
            CreateMap<RegistraPlanoSimplesInputModel, Plano>();
            CreateMap<AtualizarPlanoSimplesInputModel, Plano>();
            CreateMap<Plano, ObterPlanoPorIdentificadorOutputModel>();
            CreateMap<Plano, PlanoDTO>();
            CreateMap<Plano, ObterTodosPlanosOutputModel>();
        }
    }
}
