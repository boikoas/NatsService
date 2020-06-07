using Nats.Service.Api.HealthCheck;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
using Nats.Service.Infrastructure.Middleware;
using Autofac;
using Nats.Service.Infrastructure.Messaging.Nats;
using Nats.Service.Infrastructure.Serializers.Binary;
using Nats.Service.Infrastructure.Dispatchers;
using System;
using Nats.Setvice.Domain.Database;

namespace Nats.Service.Api
{
    /// <summary>
    /// Startup class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        private IWebHostEnvironment WebHostEnvironment { get; }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices(Configuration);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            RegisterService(builder);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseCustomHealthChecks();
            app.UseGlobalExceptionHandler();
        }

        private static void RegisterService(ContainerBuilder builder)
        {
            builder.RegisterType<NatsConfiguration>().As<INatsConfiguration>();
            builder.RegisterType<NatsManager>().As<INatsManager>().SingleInstance();
            builder.RegisterType<BinaryFormatterSerializer>().As<IBinarySerializer>().SingleInstance();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
        }
    }
}