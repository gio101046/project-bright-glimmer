using BrightGlimmer.Domain.Service;
using MediatR;
using System.Collections.Generic;

namespace BrightGlimmer.Service.Commands
{
    public class CreateStudentCommand : IRequest<Student>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Phone> Phones { get; set; }
        public Address Address { get; set; }
    }
}
