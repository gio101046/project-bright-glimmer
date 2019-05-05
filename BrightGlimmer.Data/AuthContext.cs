using BrightGlimmer.Data.Interfaces;
using BrightGlimmer.Domain.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Data
{
    public class AuthContext : DbContext, IUnitOfWork
    {
        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        {
        }

        // dotnet ef migrations add NAME --project ./BrightGlimmer.Data --startup-project ./BrightGlimmer.Auth --context AuthContext
        // dotnet ef database update --project ./BrightGlimmer.Data --startup-project ./BrightGlimmer.Auth --context AuthContext
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
