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

        public DataContext()
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(u => u.Username).IsUnique(); });
            modelBuilder.Entity<User>(entity => { entity.HasIndex(u => u.Email).IsUnique(); });
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}