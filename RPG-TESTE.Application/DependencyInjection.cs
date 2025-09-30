using Microsoft.Extensions.DependencyInjection;
using RPG_TESTE.Application.DTOs;
using RPG_TESTE.Application.Excptions;
using RPG_TESTE.Application.Interfaces.CharacterInterfaces;
using RPG_TESTE.Application.Services.CharacterService;
using RPG_TESTE.Application.Validators;
namespace RPG_TESTE.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<FluentValidation.IValidator<CharacterCreateDTO>, CreateCharacterValidator>();
            services.AddScoped<FluentValidation.IValidator<CharacterUpdateDTO>, UpdateCharacterFilter>();
            services.AddScoped<CustomExceptionFilter>();
            services.AddScoped<ICharacterQueryService, CharacterQueryService>();
            services.AddScoped<ICharacterService, CharacterService>();

            return services;
        }
    }
}
