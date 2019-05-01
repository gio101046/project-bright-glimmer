using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        public string Email { get; set; }
        public virtual Address Address { get; private set; }
        public string ProfilePictureUrl { get; set; }

        private readonly List<Phone> phones = new List<Phone>();
        public virtual IReadOnlyList<Phone> Phones => phones;

        private readonly List<AssignedCourse> assignedCourses = new List<AssignedCourse>();
        public virtual IReadOnlyList<AssignedCourse> AssignedCourses => assignedCourses;

        protected Student() { }

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

        public void Update(Student student)
        {
            FirstName = student.FirstName;
            MiddleName = student.MiddleName;
            LastName = student.LastName;
            Email = student.Email;
        }

        public void UpdateAddress(Address address)
        {
            Address.Update(address);
        }

        public bool UpdatePhone(Phone phone)
        {
            var existingPhone = Phones.SingleOrDefault(x => x.Id == phone.Id);
            if (existingPhone == null)
            {
                return false;
            }

            existingPhone.Update(phone);
            return true;
        }

        public void AddPhone(Phone phone)
        {
            phones.Add(new Phone(phone));
        }

        public void AddAssignedCourse(AssignedCourse assignedCourse)
        {
            assignedCourses.Add(new AssignedCourse(assignedCourse));
        }
    }
}
