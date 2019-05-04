using BrightGlimmer.Data.Interfaces;
using BrightGlimmer.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        // dotnet ef database update --project ./BrightGlimmer.Data --startup-project ./BrightGlimmer.Api
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

            // Make all entities soft deletables and filter by soft deleted on queries
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetOrAddProperty("IsDeleted", typeof(bool));

                var parameter = Expression.Parameter(entityType.ClrType);
                var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(bool));
                var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant("IsDeleted"));

                BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(false));

                var lambda = Expression.Lambda(compareExpression, parameter);
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<AssignedCourse> AssignedCourses { get; set; }
    }
}
