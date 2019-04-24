using BrightGlimmer.Data.Interfaces;
using BrightGlimmer.Domain;
using BrightGlimmer.Service.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrightGlimmer.Service.Handlers.CommandHandlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly ICommandRepository<Student> repository;

        public CreateStudentCommandHandler(ICommandRepository<Student> repository)
        {
            this.repository = repository;
        }

        public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student(request.FirstName,
                                      request.LastName,
                                      request.Email,
                                      request.Phones,
                                      request.Address);
            repository.Create(student);
            await repository.UnitOfWork.SaveChangesAsync();
            return student;
        }
    }
}
