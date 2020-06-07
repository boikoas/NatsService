using Nats.Service.Infrastructure.Base;
using Nats.Service.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nats.Service.Infrastructure.Database.Repositories
{
    public interface IMessageForSaveRepository : IRepositoryBase<MessageForSave>
    {
    }
}
