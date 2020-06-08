using System.Threading.Tasks;

namespace Nats.Service.Infrastructure.Services.ActionWriterService
{
    public interface IActionWriterService
    {
        Task BeginConsumeAsync();
    }
}