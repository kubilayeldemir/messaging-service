using MessagingService.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessagingService.Api.Persistence.Contexts
{
    public class MessagingContext : DbContext
    {
        public MessagingContext(DbContextOptions<MessagingContext> options)
            : base(options)
        {
        }

        public MessagingContext()
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(u => u.Username).IsUnique(); });
            modelBuilder.Entity<User>(entity => { entity.HasIndex(u => u.Email).IsUnique(); });
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MessagingContext).Assembly);
        }
    }
}