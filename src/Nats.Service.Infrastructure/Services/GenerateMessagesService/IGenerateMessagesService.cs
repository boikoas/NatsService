using System.Threading.Tasks;

namespace Nats.Service.Infrastructure.Services
{
    public interface IGenerateMessagesService
    {
        Task GenerateMessage();
    }
}