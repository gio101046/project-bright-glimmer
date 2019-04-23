using BrightGlimmer.Data.Domain;
using BrightGlimmer.Data.Interfaces;
using BrightGlimmer.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Data
{
    public class BgContext : DbContext, IUnitOfWork
    {
        public BgContext(DbContextOptions<BgContext> options)
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
