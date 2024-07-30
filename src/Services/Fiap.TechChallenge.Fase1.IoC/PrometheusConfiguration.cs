using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value == "/metrics")
                {
                    await next();
                    return;
                }

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                await next();

                stopwatch.Stop();
                var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

                var endpoint = context.GetEndpoint();
                var route = endpoint?.Metadata.GetMetadata<Microsoft.AspNetCore.Routing.RouteNameMetadata>()?.RouteName
                            ?? context.Request.Path.Value
                            ?? "unknown";

                var totalMetric = Metrics.CreateHistogram(
                    "http_request_duration_milliseconds",
                    "Duration of HTTP requests in milliseconds.",
                    new HistogramConfiguration
                    {
                        Buckets = Histogram.LinearBuckets(start: 1, width: 10, count: 10)
                    }
                );
                totalMetric.Observe(elapsedMilliseconds);

                var routeMetric = Metrics.CreateHistogram(
                    "http_request_duration_milliseconds_by_route",
                    "Duration of HTTP requests in milliseconds by route.",
                    new HistogramConfiguration
                    {
                        Buckets = Histogram.LinearBuckets(start: 1, width: 10, count: 10),
                        LabelNames = new[] { "route" }
                    }
                );
                routeMetric.WithLabels(route).Observe(elapsedMilliseconds);
            });

            app.UseMetricServer();
            app.UseHttpMetrics();

            return app;
        }
    }
}
