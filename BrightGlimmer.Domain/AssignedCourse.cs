using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BrightGlimmer.Domain
{
    [Table("AssignedCourses")]
    public class AssignedCourse : Entity
    {
        public decimal? Grade { get; set; }
        public bool IsActive { get; set; }
        public string Term { get; set; } 

        public virtual Student Student { get; private set; }
        public virtual Course Course { get; private set; }

        protected AssignedCourse() { }

        public AssignedCourse(bool isActive, string term)
        {
            IsActive = isActive;
            Term = term;
        }

        public AssignedCourse(decimal grade, bool isActive, string term)
        {
            Grade = grade;
            IsActive = isActive;
            Term = term;
        }

        public AssignedCourse(AssignedCourse assignedCourse)
        {
            Grade = assignedCourse.Grade;
            IsActive = assignedCourse.IsActive;
            Term = assignedCourse.Term;
        }

        public void Update(AssignedCourse assignedCourse)
        {
            Grade = assignedCourse.Grade;
            IsActive = assignedCourse.IsActive;
            Term = assignedCourse.Term;
        }
    }
}
