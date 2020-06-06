using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
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
            .ConfigureWebHostDefaults(webBuilder => webBuilder
            .UseStartup<Startup>());
    }
}
