using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitFun.API.Models.SQLiteModels
{
    public class SQLiteDatabaseContext : DbContext
    {
        public SQLiteDatabaseContext(DbContextOptions<SQLiteDatabaseContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SQLiteUser>().HasMany(x => x.Repositories);
        }
        
        public DbSet<SQLiteUser> SQLiteUsers { get; set; }

        public DbSet<SQLiteRepository> SQLiteRepositories { get; set; }
    }
}
