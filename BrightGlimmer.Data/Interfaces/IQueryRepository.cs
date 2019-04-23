using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrightGlimmer.Data.Interfaces
{
    public interface IQueryRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<T> Get();

        T Get(Guid id);
    }
}
