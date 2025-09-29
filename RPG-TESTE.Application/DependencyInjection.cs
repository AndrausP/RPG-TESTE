using Microsoft.Extensions.DependencyInjection;

namespace RPG_TESTE.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped < FluentValidation.IValidator<CharacterCreateDTO>,();
            return services;
        }
    }
}
