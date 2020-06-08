using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nats.Service.Infrastructure.Services.ActionWriterService
{
    public class ActionWriterService : IActionWriterService
    {
        private readonly IMessageProcessingService _messageProcessingService;
        private readonly IGenerateMessagesService _generateMessagesService;

        public ActionWriterService(IMessageProcessingService messageProcessingService, IGenerateMessagesService generateMessagesService)
        {
            _messageProcessingService = messageProcessingService;
            _generateMessagesService = generateMessagesService;
        }

        public async Task BeginConsumeAsync()
        {
            try
            {
                while (true)
                {
                    await _generateMessagesService.GenerateMessage();
                    await _messageProcessingService.MessageProcessing();
                    await Task.Delay(3000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(5000);
                await BeginConsumeAsync();
            }
        }
    }
}