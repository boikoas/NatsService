using Nats.Service.Domain.Base;
using Nats.Service.Domain.Model;
using Nats.Setvice.Infrastructure.Database;

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