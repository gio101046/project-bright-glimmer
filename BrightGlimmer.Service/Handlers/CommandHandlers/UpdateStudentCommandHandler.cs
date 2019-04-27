﻿using BrightGlimmer.Data.Interfaces;
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
            
            if (student.Address != null)
            {

            }

            return student;
        }
    }
}
