using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BrightGlimmer.Domain
{
    [Table("AssignedCourses")]
    public class AssignedCourse : Entity
    {
        public decimal Grade { get; set; }
        public bool IsActive { get; set; }
        public string Term { get; set; } 

        public Student Student { get; set; }
        public Course Course { get; set; }

        private AssignedCourse() { }

        public AssignedCourse(decimal grade, bool isActive, string term)
        {
            Grade = grade;
            IsActive = isActive;
            Term = term;
        }
    }
}
