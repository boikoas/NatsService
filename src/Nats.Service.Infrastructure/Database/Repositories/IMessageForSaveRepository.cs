﻿using Nats.Service.Domain.Model;
using Nats.Service.Infrastructure.Base;

namespace Nats.Service.Infrastructure.Database.Repositories
{
    public interface IMessageForSaveRepository : IRepositoryBase<MessageForSave>
    {
    }
}