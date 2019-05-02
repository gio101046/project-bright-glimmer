using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Service.Commands
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteStudentCommand(Guid id)
        {
            Id = id;
        }
    }
}
