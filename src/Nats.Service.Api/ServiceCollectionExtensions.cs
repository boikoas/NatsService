using Nats.Service.Api.HealthCheck;
using Nats.Service.Api.MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Nats.Service.Api
{
    /// <summary>
    /// ServiceCollectionExtensions.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавление сервисов приложения.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <param name="configuration">Конфигурация <see cref="IConfiguration"/>.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration) => services
            .AddOptions()
            .AddMvcActionFilters()
            .AddAllHealthChecks()
            .AddMediator();

        /// <summary>
        /// Добавление MVC фильтров действий.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        private static IServiceCollection AddMvcActionFilters(this IServiceCollection services) => services
            .Scan(scan =>
            {
                scan
                    .FromAssemblies(typeof(Startup).Assembly)
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IAsyncActionFilter)))
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IAsyncResultFilter)))
                    .AsSelf()
                    .WithScopedLifetime();
            });

        /// <summary>
        /// Добавление хелсчеков.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        private static IServiceCollection AddAllHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddCustomHealthChecks();

            return services;
        }



    }
}