using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RPG_TESTE.Domain.Interfaces;
using RPG_TESTE.Infrastructure.Database;
using RPG_TESTE.Infrastructure.Repositories;

namespace RPG_TESTE.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICharacterRepository, CharacterRepository>();

            return services;
        }
    }
}