using TesteDesenvolvimento.Business.Services;
using TesteDesenvolvimento.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace TesteDesenvolvimento.Business.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterService(this IServiceCollection services)
        {
            ConfigureDbsDependencyInjection(services);
            ConfigureMappersDependencyInjection(services);
            ConfigureRepositoriesDependencyInjection(services);
            ConfigureServicesDependencyInjection(services);
        }

        private static void ConfigureServicesDependencyInjection(IServiceCollection services)
        {
        }

        private static void ConfigureDbsDependencyInjection(IServiceCollection services)
        {

        }

        private static void ConfigureRepositoriesDependencyInjection(IServiceCollection services)
        {
            
        }

        private static void ConfigureMappersDependencyInjection(IServiceCollection services)
        {
        }
    }
}
