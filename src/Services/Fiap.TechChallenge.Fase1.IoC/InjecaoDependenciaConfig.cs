using Fiap.TechChallenge.Fase1.Aplicacao;
using Fiap.TechChallenge.Fase1.Aplicacao.DDDRegiao;
using Fiap.TechChallenge.Fase1.Data.Context;
using Fiap.TechChallenge.Fase1.Data.Repository;
using Fiap.TechChallenge.Fase1.Dominio;
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
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IDDDRegiaoService, DDDRegiaoService>();
            services.AddScoped<IDDDRegiaoRepository, DDDRegiaoRepository>();

            return services;
        }
    }
}
