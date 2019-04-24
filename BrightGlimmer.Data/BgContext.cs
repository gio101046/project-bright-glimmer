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


        // dotnet ef migrations add NAME --project ./BrightGlimmer.Data --startup-project ./BrightGlimmer.Api
        // dotnet ef migrations update --project ./BrightGlimmer.Data --startup-project ./BrightGlimmer.Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.StudentNumber).IsUnique();
                entity.HasOne(e => e.Address);
                entity.HasMany(e => e.Phones);
                entity.HasMany(e => e.AssignedCourses);
            });
            modelBuilder.Entity<AssignedCourse>()
                        .HasOne(x => x.Course);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<AssignedCourse> AssignedCourses { get; set; }
    }
}
