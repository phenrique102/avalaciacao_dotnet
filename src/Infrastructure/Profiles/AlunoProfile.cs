using Application.Alunos.Commands.AtualizaAlunoComPlano;
using Application.Alunos.Commands.RegistraAlunoComPlano;
using Application.Alunos.Queries.ObterAlunoPorIdentificador;
using Application.Alunos.Queries.ObterTodosAlunos;
using AutoMapper;
using Domain.Alunos;
using Domain.Planos;
using Domain.ValueObjects;

namespace Infrastructure.Profiles
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile() 
        { 
            CreateMap<RegistraAlunoComPlanoInputModel, Aluno>()
                .ForMember(dest => dest.DsSexo, opt => opt.MapFrom(src => new SexoVO(src.DsSexo)))
                .ForMember(dest => dest.Plano, opt => opt.MapFrom(src => new Plano { IdPlano = src.IdPlano, NoPlano = string.Empty }));

            CreateMap<AtualizaAlunoComPlanoInputModel, Aluno>()
                .ForMember(dest => dest.DsSexo, opt => opt.MapFrom(src => new SexoVO(src.DsSexo)))
                .ForMember(dest => dest.Plano, opt => opt.MapFrom(src => new Plano { IdPlano = src.IdPlano, NoPlano = string.Empty }));

            CreateMap<Aluno, ObterAlunoPorIdentificadorOutputModel>()
                .ForMember(dest => dest.DsSexo, opt => opt.MapFrom(src => src.DsSexo.ToString()))
                .ForMember(dest => dest.FlAtivo, opt => opt.MapFrom(src => src.FlAtivo.ToString()));

            CreateMap<Aluno, ObterTodosAlunosOutputModel>()
                .ForMember(dest => dest.DsSexo, opt => opt.MapFrom(src => src.DsSexo.ToString()))
                .ForMember(dest => dest.FlAtivo, opt => opt.MapFrom(src => src.FlAtivo.ToString()));
        }
    }
}
