using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightGlimmer.Data.Interfaces
{
    public interface IQueryRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<T> Get();

        T Get(Guid id);

        Task<T> GetAsync(Guid id);
    }
}
