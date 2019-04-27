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
    public class QueryRepository<T> : IQueryRepository<T> where T : Entity
    {
        public IUnitOfWork UnitOfWork => context;

        protected readonly BgContext context;

        public QueryRepository(BgContext context) /* TODO: Change way we inject context later */
        {
            this.context = context;
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
