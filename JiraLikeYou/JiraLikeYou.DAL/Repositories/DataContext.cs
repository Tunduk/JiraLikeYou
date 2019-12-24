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

        public DbSet<OccasionType> OccasionTypes { get; set; }

        public DbSet<PatternForOccasionType> PatternsForOccasion { get; set; }

        public DbSet<PatternForTrigger> PatternsForTrigger { get; set; }

        public DbSet<Trigger> Triggers { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Occasion> Occasions { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trigger>()
                .HasOne(p => p.OccasionType)
                .WithMany(t => t.Triggers)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PatternForOccasionType>()
                .HasOne(p => p.OccasionType)
                .WithMany(t => t.PatternsForOccasion)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PatternForTrigger>()
                .HasOne(p => p.Triggers)
                .WithMany(t => t.PatternsForTrigger)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    }
