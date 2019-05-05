using BrightGlimmer.Data.Interfaces;
using BrightGlimmer.Domain.Service;
using BrightGlimmer.Service.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrightGlimmer.Service.Handlers.CommandHandlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Student>
    {
        private readonly ICommandRepository<Student> repository;

        public UpdateStudentCommandHandler(ICommandRepository<Student> repository)
        {
            this.repository = repository;
        }

        public async Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await repository.GetAsync(request.Id);

            student.FirstName = request.FirstName;
            student.MiddleName = request.MiddleName;
            student.LastName = request.LastName;
            student.Email = request.Email;

            if (request.Address != null)
            {
                /* TODO: CALL TO SET LAT LONG */
                student.UpdateAddress(request.Address);
            }

            if (student.Phones != null)
            {
                var newPhones = new List<Phone>();
                foreach (var phone in request.Phones)
                {
                    if (!student.UpdatePhone(phone))
                    {
                        newPhones.Add(phone);
                    }
                }

                foreach (var newPhone in newPhones)
                {
                    student.AddPhone(newPhone);
                }
            }

            await repository.UnitOfWork.SaveChangesAsync();
            return student;
        }
    }
}
