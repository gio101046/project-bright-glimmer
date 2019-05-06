using BrightGlimmer.Data;
using BrightGlimmer.Data.Interfaces;
using BrightGlimmer.Data.Repositories;
using BrightGlimmer.Domain;
using JsonNet.PrivateSettersContractResolvers;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(options =>
                    {
                        // Allow private fields to deserialize
                        options.SerializerSettings.ContractResolver = new PrivateSetterContractResolver();
                    });

            /* Setup Jwt Authentication */
            var key = Encoding.UTF8.GetBytes(Configuration.GetSection("Keys")["JwtPrivateKey"]); /* TODO: Change to Azure Key Vault */
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false, /* TODO: Add validation for both issuer and audience */
                    ValidateAudience = false
                };
            });

            /* Setup MediatR */
            services.AddMediatR();
            services.AddMediatR(typeof(Cqrs.Cqrs).Assembly); // Registers handlers in services project

            /* Setup Injectable Repos */
            services.AddTransient(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddTransient(typeof(ICommandRepository<>), typeof(CommandRepository<>));

            /* Configure EF Core DbContext */
            services.AddDbContext<BgContext>(options => options.UseLazyLoadingProxies()
                                                               .UseSqlite(Configuration.GetConnectionString("DefaultConnection"))); /* TODO: Change to Azure Key Vault */
            services.AddTransient<BgContext, BgContext>();
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
            app.UseAuthentication();
            app.UseMvc();

            // Makes sure that the database is in fact created
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<BgContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}