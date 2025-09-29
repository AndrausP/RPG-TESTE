using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RPG_TESTE.Infrastructure.Repositories;
using RPG_TESTE.Domain.Interfaces;
using RPG_TESTE.Domain;

namespace RPG_TESTE.Infrastructure
{
    static class DependencyInjection 
    {
        public static  IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICharacterRepository, CharacterRepository>();

            return services;
        }
    }
}
