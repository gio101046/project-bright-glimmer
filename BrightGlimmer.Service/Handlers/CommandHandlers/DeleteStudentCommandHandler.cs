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
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly ICommandRepository<Student> repository;

        public DeleteStudentCommandHandler(ICommandRepository<Student> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await repository.GetAsync(request.Id);

            student.Address?.Delete();
            student.AssignedCourses.ToList().ForEach(x => x.Delete());
            student.Phones.ToList().ForEach(x => x.Delete());
            student.Delete();

            await repository.UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
