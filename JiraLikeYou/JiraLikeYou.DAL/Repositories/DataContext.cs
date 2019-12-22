using System;
using System.Collections.Generic;
using System.Text;
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

        public DbSet<History> History { get; set; }

        public DbSet<HistoryFields> HistoryFields { get; set; }

        public DbSet<Media> Media { get; set; }

        public DbSet<SettingDefaultPatterns> SettingDefaultPatterns { get; set; }

        public DbSet<SettingPatterns> SettingPatterns { get; set; }

        public DbSet<SettingScripts> SettingScripts { get; set; }

        public DbSet<SettingTriggers> SettingTriggers { get; set; }
    }
}
