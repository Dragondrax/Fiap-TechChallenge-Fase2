using Fiap.TechChallenge.Fase1.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.TechChallenge.Fase1.IoC
{
    public static class InjecaoDependenciaConfig
    {
        public static IServiceCollection ResolverDependencia(this IServiceCollection services)
        {
            services.AddScoped<ContextTechChallenge>();

            return services;
        }
    }
}
