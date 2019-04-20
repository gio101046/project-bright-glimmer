using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Data.Domain
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Phone> Phones { get; set; }
    }
}
