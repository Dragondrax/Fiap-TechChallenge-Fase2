using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Prometheus;

namespace Fiap.TechChallenge.Fase1.IoC
{
    public static class PrometheusConfiguration
    {
        public static IApplicationBuilder Handle(this IApplicationBuilder app)
        {
            var counter = Metrics.CreateCounter("FiapMetrics", "Metricas API", new CounterConfiguration
            {
                LabelNames = new[] { "method", "endpoint" }
            });

            app.Use((context, next) =>
            {
                counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
                return next();
            });


            app.UseMetricServer();
            app.UseHttpMetrics();

            return app;
        }
    }
}
