using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddAcademiaProject(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddIoCLibrary();
            services.AddIoCRepository(configurationManager);
            services.AddIoCAuthentication(configurationManager);
        }
    }
}
