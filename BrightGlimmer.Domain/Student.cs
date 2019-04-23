using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Domain
{
    public class Student : Entity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Phone> Phones { get; set; }
    }
}
