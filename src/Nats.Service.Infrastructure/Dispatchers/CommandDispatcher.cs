using Nats.Service.Infrastructure.Messaging.Nats;
using System.Threading.Tasks;

namespace Nats.Service.Infrastructure.Dispatchers
{
    public interface ICommandDispatcher
    {
        Task<ReplyMessage> SendAsync<T>(T command);
    }

    public sealed class CommandDispatcher : ICommandDispatcher
    {
        private readonly INatsManager _natsManager;

        public CommandDispatcher(INatsManager natsManager)
        {
            _natsManager = natsManager;
        }

        Task<ReplyMessage> ICommandDispatcher.SendAsync<T>(T command)
        {
            return _natsManager.RequestAsync(
                typeof(T).Name,
                new CommandMessage<T>(command));
        }
    }
}