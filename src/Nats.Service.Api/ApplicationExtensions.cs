using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nats.Service.Infrastructure.Services.ActionWriterService;
using System.Threading.Tasks;

namespace Nats.Service.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static async Task<IApplicationBuilder> UseActionsSubscriptionAsync(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var actionReader = serviceScope.ServiceProvider.GetRequiredService<IActionWriterService>();
                await actionReader.BeginConsumeAsync();

                return app;
            }
        }
    }
}