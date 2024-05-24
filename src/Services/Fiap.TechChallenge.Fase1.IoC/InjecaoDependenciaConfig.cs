using Fiap.TechChallenge.Fase1.Data.Context;
using Fiap.TechChallenge.Fase1.Data.Repository;
using Fiap.TechChallenge.Fase1.Data.Repository.Usuario;
using Fiap.TechChallenge.Fase1.Dominio;
using Fiap.TechChallenge.Fase1.Dominio.Token;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.TechChallenge.Fase1.IoC
{
    public static class InjecaoDependenciaConfig
    {
        public static IServiceCollection ResolverDependencia(this IServiceCollection services)
        {
            services.AddScoped<ContextTechChallenge>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
