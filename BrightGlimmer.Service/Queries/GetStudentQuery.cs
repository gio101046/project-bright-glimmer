using BrightGlimmer.Domain;
using MediatR;
using System;

namespace BrightGlimmer.Service.Queries
{
    public class GetStudentQuery : IRequest<Student>  
    {
        public Guid Id { get; set; }

        public GetStudentQuery(Guid id)
        {
            Id = id;
        }
    }
}
