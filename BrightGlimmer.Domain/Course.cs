using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BrightGlimmer.Domain
{
    [Table("Courses")]
    public class Course : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Code { get; private set; }

        private Course() { }

        public Course(string name, string description, string code)
        {
            Name = name;
            Description = description;
            Code = code;
        }
    }
}
