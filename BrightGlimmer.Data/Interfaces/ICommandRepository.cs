using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightGlimmer.Data.Interfaces
{
    public interface ICommandRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }

        T Create(T entity);

        T Update(T entity);

        void Remove(Guid id);

        IQueryable<T> Get();

        T Get(Guid id);

        Task<T> GetAsync(Guid id);
    }
}
