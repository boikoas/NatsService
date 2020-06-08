using System.Threading.Tasks;

namespace Nats.Service.Infrastructure.Services
{
    public interface IMessageProcessingService
    {
        Task MessageProcessing();
    }
}