using Microsoft.EntityFrameworkCore;
using Nats.Service.Infrastructure.Model;

namespace Nats.Setvice.Domain.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<MessageForSend> MessagesForSend{ get; set; }

        public DbSet<MessageForSave> MessagesForSave { get; set; }

    }
}
