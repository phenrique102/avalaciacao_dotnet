using Application.Interfaces;
using Application.Usuarios.Commands.RegistraUsuarioInterno;
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

            services.AddScoped<IRegistroUsuarioInternoCommand, RegistroUsuarioInternoCommand>();
        }
    }
}
