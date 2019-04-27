using BrightGlimmer.Data.Interfaces;
using BrightGlimmer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightGlimmer.Data.Repositories
{
    public class StudentQueryRepository : QueryRepository<Student>
    {
        public StudentQueryRepository(BgContext context) : base(context) { }

        public override IQueryable<Student> Get()
        {
            return context.Students
                          .Include(x => x.Phones)
                          .Include(x => x.Address)
                          .Include(x => x.AssignedCourses);
        }

        public override Student Get(Guid id)
        {
            return context.Students
                          .Include(x => x.Phones)
                          .Include(x => x.Address)
                          .Include(x => x.AssignedCourses)
                          .Single(x => x.Id == id);
        }

        public override async Task<Student> GetAsync(Guid id)
        {
            return await context.Students
                                .Include(x => x.Phones)
                                .Include(x => x.Address)
                                .Include(x => x.AssignedCourses)
                                .SingleAsync(x => x.Id == id);
        }
    }
}
