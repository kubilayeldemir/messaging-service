using MessagingService.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessagingService.Api.Persistence.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(u => u.Username).IsUnique(); });
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasIndex(nameof(Message.ReceiverUserId), nameof(Message.SenderUserId));
            });
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}