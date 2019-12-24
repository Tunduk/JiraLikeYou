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

        public DbSet<ConfigOccasionType> ConfigOccasionType { get; set; }

        public DbSet<ConfigPatternOccasion> ConfigPatternOccasion { get; set; }

        public DbSet<ConfigPatternTrigger> ConfigPatternTrigger { get; set; }

        public DbSet<ConfigTrigger> ConfigTrigger { get; set; }

        public DbSet<Ticket> Ticket { get; set; }

        public DbSet<Occasion> Occasion { get; set; }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigTrigger>()
                .HasOne(p => p.ConfigOccasionType)
                .WithMany(t => t.ConfigTriggers)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ConfigPatternOccasion>()
                .HasOne(p => p.ConfigOccasionType)
                .WithMany(t => t.ConfigPatternOccasion)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ConfigPatternTrigger>()
                .HasOne(p => p.ConfigTriggers)
                .WithMany(t => t.ConfigPatternTrigger)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    }
