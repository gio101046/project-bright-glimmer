using BrightGlimmer.Data.Interfaces;
using BrightGlimmer.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrightGlimmer.Data.Repositories
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(BgContext context) : base(context) { }
    }
}
