using Nats.Service.Domain.Model;
using Nats.Service.Infrastructure.Database.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nats.Service.Infrastructure.Services
{
    public class GenerateMessagesService : IGenerateMessagesService
    {
        private readonly IMessageForSendRepository _messageForSendRepository;

        public GenerateMessagesService(IMessageForSendRepository messageForSendRepository)
        {
            _messageForSendRepository = messageForSendRepository;
        }

        public async Task GenerateMessage()
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                await _messageForSendRepository.CreateAsync(new MessageForSend()
                {
                    Text = RandomString(random, random.Next(10, 50))
                });
            }
        }

        private static string RandomString(Random random, int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}