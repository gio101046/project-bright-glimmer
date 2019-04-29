using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BrightGlimmer.Domain
{
    [Table("Courses")]
    public class Course : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        private Course() { }

        public Course(string name, string description, string code)
        {
            Name = name;
            Description = description;
            Code = code;
        }

        public void Update(Course course)
        {
            Name = course.Name;
            Description = course.Description;
            Code = course.Code;
        }
    }
}
