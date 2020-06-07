using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;


namespace Nats.Service.Api
{
    /// <summary>
    /// Program class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        /// <param name="args">arguments of string[].</param>
        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webHostBuilder =>
            {
                webHostBuilder
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        var env = hostingContext.HostingEnvironment;
                        config.SetBasePath(Directory.GetCurrentDirectory());
                        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                        config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, true);
                        config.AddEnvironmentVariables();
                    })
                    .UseStartup<Startup>();
            });
    }
}
