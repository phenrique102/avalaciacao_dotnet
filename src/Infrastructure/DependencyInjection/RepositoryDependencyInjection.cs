using Application.Interfaces;
using Domain.Usuarios;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace Infrastructure.DependencyInjection
{
    public static class RepositoryDependencyInjection
    {
        public static void AddIoCRepository(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddSingleton(new MySqlConnection(configurationManager.GetConnectionString("DefaultConnection")));
            services.AddTransient<IBancoDadosRepository, BancoDadosRepository>();
            services.AddSingleton<IRepository<Usuario>, Repository<Usuario>>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPlanoRepository, PlanoRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
        }
    }
}
