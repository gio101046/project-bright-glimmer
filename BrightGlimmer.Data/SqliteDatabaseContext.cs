using BrightGlimmer.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Data
{
    public class SqliteDatabaseContext : DbContext
    {
        public SqliteDatabaseContext(DbContextOptions<SqliteDatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasMany(x => x.Phones);
        }

        public DbSet<Student> Students { get; set; }
    }
}
