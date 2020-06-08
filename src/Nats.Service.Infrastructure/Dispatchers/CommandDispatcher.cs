using Nats.Service.Domain.Model;
using Nats.Service.Infrastructure.Messaging.Nats;
using System;
using System.Threading.Tasks;

namespace Nats.Service.Infrastructure.Dispatchers
{
    public interface ICommandDispatcher
    {
        Task<ReplyMessage> SendAsync<T>(T command);

        Task PublishAsync<T>(string topic, T data);
    }

    public sealed class CommandDispatcher : ICommandDispatcher
    {
        private readonly INatsManager _natsManager;

        public CommandDispatcher(INatsManager natsManager)
        {
            _natsManager = natsManager;
        }

        public event EventHandler<CommandMessage<MessageForSave>> GotMessage;

        Task<ReplyMessage> ICommandDispatcher.SendAsync<T>(T command)
        {
            return _natsManager.RequestAsync(
                typeof(T).Name,
                new CommandMessage<T>(command));
        }

        public Task PublishAsync<T>(string topic, T data)
        {
            return _natsManager.PublishAsync<T>(topic, data);
        }
    }
}