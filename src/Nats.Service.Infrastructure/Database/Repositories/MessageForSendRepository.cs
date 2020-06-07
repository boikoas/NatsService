using Nats.Service.Domain.Base;
using Nats.Service.Domain.Model;
using Nats.Setvice.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nats.Service.Infrastructure.Database.Repositories
{
    public class MessageForSendRepository : RepositoryBase<MessageForSend>, IMessageForSendRepository
    {
        public MessageForSendRepository(AppDbContext repositoryContext)
          : base(repositoryContext)
        {
        }
    }
}
