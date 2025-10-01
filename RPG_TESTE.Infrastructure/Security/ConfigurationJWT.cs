using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RPG_TESTE.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RPG_TESTE.Domain.Enums;
namespace RPG_TESTE.Infrastructure.Security
{
    public static class ConfigurationJWT
    {
        public static IServiceCollection AddAuthConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSection = configuration.GetSection(JwtOptions.SectionName);
            var secretKey = jwtSection["Secret"];
            if (string.IsNullOrEmpty(secretKey))
                throw new InvalidOperationException("The JWT secret key ('JwtOptions:Secret') was not found or is empty. Check the appsettings.json.");
            services.Configure<JwtOptions>(jwtSection);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSection["Issuer"],
                    ValidAudience = jwtSection["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Master", policy => policy.RequireRole(UserEnum.Master.ToString()));
                options.AddPolicy("Player", policy => policy.RequireRole(UserEnum.Player.ToString(), UserEnum.Player.ToString()));
            });
            services.AddScoped<IJwtTokenGeneration, JwtTokenGenerator>();
            return services;
        }
    }
}
