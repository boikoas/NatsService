using Microsoft.EntityFrameworkCore;
using Nats.Service.Domain.Model;

namespace Nats.Setvice.Infrastructure.Database
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

        public DbSet<MessageForSend> MessagesForSend { get; set; }

        public DbSet<MessageForSave> MessagesForSave { get; set; }
    }
}