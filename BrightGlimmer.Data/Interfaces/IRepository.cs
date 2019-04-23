using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrightGlimmer.Data.Interfaces
{
    public interface IRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }

        T Create(T entity);

        T Update(T entity);

        void Remove(Guid id);

        IQueryable<T> Get();

        T Get(Guid id);
    }
}
