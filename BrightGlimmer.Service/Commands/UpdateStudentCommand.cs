using BrightGlimmer.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Service.Commands
{
    public class UpdateStudentCommand : IRequest<Student>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Phone> Phones { get; set; }
        public Address Address { get; set; }
    }
}
