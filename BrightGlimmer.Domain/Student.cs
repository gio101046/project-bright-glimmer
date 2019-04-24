using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BrightGlimmer.Domain
{
    [Table("Students")]
    public class Student : Entity
    {
        [NotMapped]
        private readonly int MAX_STUDENT_NUMBER = 100000000;

        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Phone> Phones { get; set; }
        public Address Address { get; set; }
        public string ProfilePictureUrl { get; set; }
        public List<AssignedCourse> AssignedCourses { get; set; }

        public Student() : base()
        {
            StudentNumber = new Random().Next(MAX_STUDENT_NUMBER); /* TODO: Optimize student number creation */
        }
    }
}
