using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrightGlimmer.Data;
using BrightGlimmer.Data.Repositories; /* REMOVE LATER */
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BrightGlimmer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMediatR();
            services.AddMediatR(typeof(Cqrs.Cqrs).Assembly); // Registers handlers in Cqrs project
            services.AddScoped<StudentRepository, StudentRepository>(); /* REMOVE LATER */
            services.AddDbContext<SqliteContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<SqliteContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // Makes sure that the database is in fact created
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<SqliteContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}