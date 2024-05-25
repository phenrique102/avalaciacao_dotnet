using Application.Alunos.Commands.ApagarAlunoComPlano;
using Application.Alunos.Commands.AtualizaAlunoComPlano;
using Application.Alunos.Commands.RegistraAlunoComPlano;
using Application.Alunos.Queries.ObterAlunoPorIdentificador;
using Application.Alunos.Queries.ObterTodosAlunos;
using Application.Interfaces;
using Application.Planos.Commands.ApagarPlanoSimples;
using Application.Planos.Commands.AtualizarPlanoSimples;
using Application.Planos.Commands.RegistraPlanoSimples;
using Application.Planos.Queries.ObterPlanoPorIdentificador;
using Application.Planos.Queries.ObterTodosPlanos;
using Application.Usuarios.Commands.RegistraUsuarioInterno;
using Application.Usuarios.Queries.LoginComCredenciais;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class IocDependencyInjection
    {
        public static void AddIoCLibrary(this IServiceCollection services)
        {
            services.AddScoped<IMapperService, MapperService>();
            services.AddScoped<ICryptService, CryptService>();
            services.AddScoped<IPatternAuthenticationService, PatternAuthenticationService>();

            services.AddScoped<IRegistroUsuarioInternoCommand, RegistroUsuarioInternoCommand>();
            services.AddScoped<ILoginComCredenciaisQuerie, LoginComCredenciaisQuerie>();
            services.AddScoped<IRegistraPlanoSimplesCommand, RegistraPlanoSimplesCommand>();
            services.AddScoped<IRegistraAlunoComPlanoCommand, RegistraAlunoComPlanoCommand>();
            services.AddScoped<IAtualizarPlanoSimplesCommand, AtualizarPlanoSimplesCommand>();
            services.AddScoped<IAtualizaAlunoComPlanoCommand, AtualizaAlunoComPlanoCommand>();
            services.AddScoped<IObterPlanoPorIdentificadorQuerie, ObterPlanoPorIdentificadorQuerie>();
            services.AddScoped<IObterAlunoPorIdentificadorQuerie, ObterAlunoPorIdentificadorQuerie>();
            services.AddScoped<IObterTodosPlanosQuerie, ObterTodosPlanosQuerie>();
            services.AddScoped<IObterTodosAlunosQuerie, ObterTodosAlunosQuerie>();
            services.AddScoped<IApagarPlanoSimplesCommand, ApagarPlanoSimplesCommand>();
            services.AddScoped<IApagarAlunoComPlanoCommand, ApagarAlunoComPlanoCommand>();
        }
    }
}
