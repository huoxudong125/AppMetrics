﻿using App.Metrics.Configuration;
using App.Metrics.Extensions.Middleware.DependencyInjection.Options;
using App.Metrics.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace App.Metrics.Extensions.Middleware.Integration.Facts.Startup
{
    public class CustomHealthCheckTestStartup : TestStartup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            SetupAppBuilder(app, env, loggerFactory);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appMetricsOptions = new AppMetricsOptions
            {
                DefaultContextLabel = "testing",
                MetricsEnabled = true
            };

            var aspNetMetricsOptions = new AspNetMetricsOptions
            {
                MetricsTextEndpointEnabled = true,
                HealthEndpointEnabled = true,
                MetricsEndpointEnabled = true,
                PingEndpointEnabled = true,
                HealthEndpoint = new PathString("/health-status")
            };

            SetupServices(services, appMetricsOptions, aspNetMetricsOptions);
        }
    }
}