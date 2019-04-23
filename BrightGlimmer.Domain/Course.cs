using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Domain
{
    public class Course : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}
