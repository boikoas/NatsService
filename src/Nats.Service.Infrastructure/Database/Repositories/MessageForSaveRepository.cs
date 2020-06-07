using Nats.Service.Domain.Base;
using Nats.Service.Infrastructure.Model;
using Nats.Setvice.Domain.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nats.Service.Infrastructure.Database.Repositories
{
    public class MessageForSaveRepository : RepositoryBase<MessageForSave>, IMessageForSaveRepository
    {
        public MessageForSaveRepository(AppDbContext repositoryContext)
          : base(repositoryContext)
        {
        }
    }
}
