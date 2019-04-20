using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Data.Domain
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

    }
}
