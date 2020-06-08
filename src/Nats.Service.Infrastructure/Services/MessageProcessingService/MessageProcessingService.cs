using Nats.Service.Domain.Model;
using Nats.Service.Infrastructure.Database.Repositories;
using Nats.Service.Infrastructure.Dispatchers;
using System;
using System.Threading.Tasks;

namespace Nats.Service.Infrastructure.Services
{
    public class MessageProcessingService : IMessageProcessingService
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IMessageForSendRepository _messageForSendRepository;
        private readonly IMessageForSaveRepository _messageForSaveRepository;

        public MessageProcessingService(ICommandDispatcher commandDispatcher,
                                        IMessageForSendRepository messageForSendRepository,
                                        IMessageForSaveRepository messageForSaveRepository)
        {
            _commandDispatcher = commandDispatcher;
            _messageForSendRepository = messageForSendRepository;
            _messageForSaveRepository = messageForSaveRepository;
        }

        public async Task MessageProcessing()
        {
            var messagesForSend = await _messageForSendRepository.FindAllAsync();
            foreach (var message in messagesForSend)
            {
                try
                {
                    await _commandDispatcher
                         .PublishAsync<MessageForSave>("NATS", new MessageForSave()
                         {
                             Guid = message.Guid,
                             Number = message.Id,
                             Text = message.Text,
                             TimeSend = DateTime.Now,
                             HashCode = _messageForSendRepository.GetHashCode()
                         });

                    message.Delete();

                    await _messageForSendRepository.UpdateAsync(message);
                }
                catch
                {
                    await Task.Delay(1000);
                }
            }
        }
    }
}