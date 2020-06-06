using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Nats.Service.Api.MediatR
{
    [ExcludeFromCodeCoverage]
    internal static class MediatRExtensions
    {
        // TODO: Изменить неймспейсы на соответствующие неймспейсы проектов Application и Infrastructure вашего солюшена!
        // Например: $"{nameof(AlfaBank)}.{nameof(TemplateProject)}.{nameof(Infrastructure)}"
        private static string ApplicationProjectNameSpace => $"{nameof(Nats)}.{nameof(Service)}.{nameof(Application)}";

        private static string InfrastructureProjectNameSpace => $"{nameof(Nats)}.{nameof(Service)}.{nameof(Infrastructure)}";

        /// <summary>
        /// Добавление MediatR.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddMediator(this IServiceCollection services) => services
            .AddMediatR(typeof(Startup))
            .AddPipelineBehavior()
            .AddDomainHandlers();

        /// <summary>
        /// Добавление обработчиков.
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <returns><see cref="IServiceCollection"/></returns>
        private static IServiceCollection AddDomainHandlers(this IServiceCollection services) => services
            .Scan(scan =>
            {
                scan
                    .FromAssemblies(Assembly.Load(ApplicationProjectNameSpace), Assembly.Load(InfrastructureProjectNameSpace))
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IRequestHandler<>)))
                    .AsImplementedInterfaces()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IRequestHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

        /// <summary>
        /// Добавление обработчика <see cref="IPipelineBehavior{TRequest, TResponse}"/>.
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <returns><see cref="IServiceCollection"/></returns>
        private static IServiceCollection AddPipelineBehavior(this IServiceCollection services) => services
            .Scan(scan =>
            {
                scan
                    .FromAssemblies(Assembly.Load(ApplicationProjectNameSpace))
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IPipelineBehavior<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });
    }
}
