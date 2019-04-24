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

        public int StudentNumber { get; private set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; private set; }
        public Address Address { get; set; }
        public string ProfilePictureUrl { get; set; }

        private readonly List<Phone> phones = new List<Phone>();
        public IReadOnlyList<Phone> Phones => phones;

        private readonly List<AssignedCourse> assignedCourses = new List<AssignedCourse>();
        public IReadOnlyList<AssignedCourse> AssignedCourses => assignedCourses;

        private Student() { }

        public Student(string firstName, 
                       string lastName, 
                       string email,
                       List<Phone> phones,
                       Address address) : base()
        {
            StudentNumber = new Random().Next(MAX_STUDENT_NUMBER); /* TODO: Optimize student number creation */
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            this.phones = phones;
        }

        public void AddPhone(Phone phone)
        {
            phones.Add(phone);
        }

        public void AddAssignedCourse(AssignedCourse assignedCourse)
        {
            assignedCourses.Add(assignedCourse);
        }
    }
}
