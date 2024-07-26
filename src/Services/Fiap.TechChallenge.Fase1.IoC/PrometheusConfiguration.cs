using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Prometheus;
using System.Diagnostics;

namespace Fiap.TechChallenge.Fase1.IoC
{
    public static class PrometheusConfiguration
    {
        public static IApplicationBuilder Handle(this IApplicationBuilder app)
        {
            var counter = Metrics.CreateCounter("FiapMetrics", "Metricas API", new CounterConfiguration
            {
                LabelNames = new[] { "method", "endpoint" },

            });

            app.Use((context, next) =>
            {
                counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
                return next();
            });

            app.Use((context, next) =>
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                context.Response.OnStarting(() =>
                {
                    stopwatch.Stop();
                    var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

                    var metric = Metrics.CreateHistogram("http_request_duration_milliseconds", "Duration of HTTP requests in milliseconds.");
                    metric.Observe(elapsedMilliseconds);

                    return Task.CompletedTask;
                });

                return next();
            });


            app.UseMetricServer();
            app.UseHttpMetrics();

            return app;
        }
    }
}
