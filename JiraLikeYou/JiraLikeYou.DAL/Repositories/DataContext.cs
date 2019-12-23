using JiraLikeYou.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace JiraLikeYou.DAL.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DataContext(string connectionString)
            : base(new DbContextOptionsBuilder<DataContext>().UseSqlite(connectionString).Options)
        {
        }

        public DbSet<ConfigEventType> ConfigEventType { get; set; }

        public DbSet<ConfigPatternEvent> ConfigPatternEvent { get; set; }

        public DbSet<ConfigPatternTrigger> ConfigPatternTrigger { get; set; }

        public DbSet<ConfigTrigger> ConfigTrigger { get; set; }

        public DbSet<TicketHistory> TicketHistory { get; set; }

        public DbSet<EventHistory> EventHistory { get; set; }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigTrigger>()
                .HasOne(p => p.ConfigEventType)
                .WithMany(t => t.ConfigTriggers)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ConfigPatternEvent>()
                .HasOne(p => p.ConfigEventType)
                .WithMany(t => t.ConfigPatternsEvent)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ConfigPatternTrigger>()
                .HasOne(p => p.ConfigTriggers)
                .WithMany(t => t.ConfigPatternsTrigger)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    }
