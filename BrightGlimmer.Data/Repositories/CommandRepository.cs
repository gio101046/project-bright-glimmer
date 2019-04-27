using BrightGlimmer.Data.Interfaces;
using BrightGlimmer.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightGlimmer.Data.Repositories
{
    public class CommandRepository<T> : ICommandRepository<T> where T : Entity
    {
        public IUnitOfWork UnitOfWork => context;

        protected readonly BgContext context;

        public CommandRepository(BgContext context) /* TODO: Change way we inject context later */
        {
            this.context = context;
        }

        public virtual T Create(T entity)
        {
            return context.Set<T>().Add(entity).Entity;
        }

        public virtual T Update(T entity)
        {
            return context.Set<T>().Update(entity).Entity;
        }

        public virtual void Remove(Guid id)
        {
            context.Set<T>().Remove(Get(id));
        }

        public virtual IQueryable<T> Get()
        {
            return context.Set<T>();
        }

        public virtual T Get(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await context.Set<T>().SingleAsync(x => x.Id == id);
        }
    }
}
